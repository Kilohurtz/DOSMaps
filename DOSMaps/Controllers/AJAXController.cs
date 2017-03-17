using DOSMaps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
namespace DOSMaps.Controllers
{
    public class AJAXController : Controller
    {
        public ActionResult Index() // This page lets the admin set the data into the database and correct rows
        {
            List<Chunk> multis = Data.GetMultis().Where(m => m.MultiComplete.HasValue && m.MultiComplete.Value == false).ToList();
            List<Country> unnamedCountries = Data.GetCountries().Where(m => m.Name == "").ToList();
            AdminPageModel model = new AdminPageModel(multis, unnamedCountries);
            return View(model); 
        }

        [HttpPost]
        public String ImportPrayersFor(String str) // Imports data about countries that are praying for each other
        {
            //Import Country name to Country code reference file
            List<Chunk> chunks = Data.GetChunks();
            List<Country> countries = Data.GetCountries();
            List<Part> parts = Data.GetParts();
            List<Chunk> multis = Data.GetMultis();
            List<String> prayerRows = str.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();                                       // Split CSV by line
            List<List<String>> rows = prayerRows.Select(m => m.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();     // Split each line by ','
            rows = rows.Where(m => m.Count() != 0).ToList();                                                                                            // Remove empty entries
            List<PrayersFor> prayersList = new List<PrayersFor>();

            //Create a database row for each entry in the CSV
            foreach (List<String> row in rows)
            {
                List<Chunk> fromList = new List<Chunk>();
                List<Chunk> toList = new List<Chunk>();

                // Parse which kind of chunk it is, and create an object accordingly
                Chunk fromChunk = chunks.Single(m => m.ID == row.ElementAt(0));
                switch (fromChunk.Type)
                {
                    case 0: //Part
                        Part fromPart = parts.Single(m => m.Chunk_ID == fromChunk.ID);
                        Country fromPartCountry = countries.Single(m => m.ID == fromPart.Country_ID);
                        Chunk fromPartCountryChunk = chunks.Single(m => m.ID == fromPartCountry.Chunk_ID);
                        fromList.Add(fromPartCountryChunk);
                        break;
                    case 1: //Country
                        fromList.Add(fromChunk);
                        break;
                    case 2: //Multi
                        foreach(Country country in fromChunk.Countries)
                        {
                            Chunk fromMultiCountryChunk = chunks.Single(m => m.ID == country.Chunk_ID);
                            fromList.Add(fromMultiCountryChunk);
                        }
                    break;
                }

                // Parse which kind of chunk it is, and create an object accordingly
                Chunk toChunk = chunks.Single(m => m.ID == row.ElementAt(2));
                switch (toChunk.Type)
                {
                    case 0: //Part
                        Part toPart = parts.Single(m => m.Chunk_ID == toChunk.ID);
                        Country toPartCountry = countries.Single(m => m.ID == toPart.Country_ID);
                        Chunk toPartCountryChunk = chunks.Single(m => m.ID == toPartCountry.Chunk_ID);
                        toList.Add(toPartCountryChunk);
                    break;
                    case 1: //Country
                        toList.Add(toChunk);
                    break;
                    case 2: //Multi
                        foreach (Country country in toChunk.Countries)
                        {
                            Chunk toMultiCountryChunk = chunks.Single(m => m.ID == country.Chunk_ID);
                            toList.Add(toMultiCountryChunk);
                        }
                    break;
                }
                //Every association needs a PrayersFor object
                foreach(Chunk from in fromList)
                {
                    foreach(Chunk to in toList)
                    {
                        PrayersFor prayersFor = new PrayersFor();
                        prayersFor.ID = Guid.NewGuid();
                        prayersFor.FromChunk_ID = from.ID;
                        prayersFor.ToChunk_ID = to.ID;
                        if(!prayersList.Exists(m => m.FromChunk_ID == prayersFor.FromChunk_ID && m.ToChunk_ID == prayersFor.ToChunk_ID))
                        {
                            prayersList.Add(prayersFor);
                        }
                    }
                }
            }
            Data.SavePrayersFor(prayersList); // Save to database

            return "success!";
        }

        [HttpPost]
        public String ImportConversions(String str) // Import Country name -> Country code table
        {
            //Import Country name to Country code reference file
            List<String> conversions = str.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();                                      // Split CSV by line
            List<List<String>> rows = conversions.Select(m => m.Split(new char[] { ',' }, 2, StringSplitOptions.RemoveEmptyEntries).ToList()).ToList(); // Split each line by ','
            rows = rows.Where(m => m.Count() != 0).ToList();                                                                                            // Remove empty entries
            List<Conversion> conversionList = new List<Conversion>();

            //Create a database row for each entry in the CSV
            foreach(List<String> row in rows) 
            {
                Conversion cnv = new Conversion();
                cnv.Code = row.First().ToLower();
                cnv.CountryName = row.ElementAt(1).Replace("\"", "");
                conversionList.Add(cnv);
            }
            Data.SaveConversions(conversionList); // Save to database
            
            return "success!";
        }

        [HttpPost]
        public String UpdateMulti(String ID, String countryNames) // Save a country object for each country in a multi
        {
            //Split saved country names by comma
            List<String> countryNameList = countryNames.Split(',').ToList().Where(m => m.Count() != 0).ToList();
            List<Country> allCountries = Data.GetCountries();
            List<Chunk> countryChunks = new List<Chunk>();
            List<Country> countries = new List<Country>();
            List<Continent> contintents = Data.GetContinents();
            List<Conversion> conversions = Data.GetConversions();
            Chunk chunk = Data.GetChunk(ID);
            //Create a chunk and country for each name
            foreach (String countryName in countryNameList)
            {
                Chunk countryChunk = Data.CreateChunk(ID: "A" + (allCountries.Count() + countries.Count() + 1).ToString().PadLeft(3, '0'),
                                                type: 2,
                                                continent_ID: chunk.Continent_ID, 
                                                shortName: countryName,
                                                longName: countryName,
                                                fullDescription: countryName,
                                                prayerNeed: chunk.PrayerNeed,                     
                                                prayerResource: chunk.PrayerResource);
                countryChunks.Add(countryChunk);
                Country country = Data.CreateCountry(ID: Guid.NewGuid(),
                                                        givenName: countryName,
                                                        chunk_ID: countryChunk.ID,
                                                        prayerNeed: chunk.PrayerNeed,
                                                        prayerResource: chunk.PrayerResource,
                                                        multiChunk_ID: chunk.ID);
                // If the country can be found in the conversion database, set it's code now
                String countryCode = conversions.Where(m => m.CountryName == countryName).FirstOrDefault()?.Code;
                if (countryCode != "" && countryCode != null)
                {
                    country.Name = country.GivenName;
                    country.Code = countryCode;
                }
                countries.Add(country);
            }
            Data.SaveMulti(ID, countryChunks, countries); // Save to database

            return "success!";
        }

        [HttpPost]
        public String UpdateCountryName(Guid ID, String countryName) // Searches for country in conversion database, and assigns code if one is found
        {
            Country modify = Data.GetCountry(ID);
            List<Conversion> conversions = Data.GetConversions();
            // If the country can be found in the conversion database, set it's code now
            String countryCode = conversions.Where(m => m.CountryName == countryName).FirstOrDefault()?.Code;       //If that country name has an easily identified code, add it
            if (countryCode != "" && countryCode != null)
            {
                Data.SaveCountryName(ID, countryName, countryCode); // Save to database
                return "success!";
            }

            return "couldn't find name.";
        }

        [HttpPost]
        public String ImportData(String str) // Imports all chunk, country, part, multi and percentage data into database
        {
            //Import data about prayer per country
            List<Conversion> conversions = Data.GetConversions();
            List<Continent> contintents = Data.GetContinents();

            List<String> input = str.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();    // Split Tab delineated file by line
            List<List<String>> rows = input.Select(m => m.Split(new char[] { '\t' }).ToList()).ToList();        // Split each line by tab
            rows = rows.Where(m => m.Count() != 0).ToList();                                                    // Remove empty entries

            List<Chunk> chunkList = new List<Chunk>();
            List<Country> countryList = new List<Country>();
            List<Part> partList = new List<Part>();
            List<String> lookup = new List<String> { "Part", "Cntry", "Multi" };
            foreach (List<String> row in rows)
            {
                Chunk chunk = Data.CreateChunk( ID: row.ElementAt(0),
                                                type: lookup.IndexOf(row.ElementAt(2)),                                         //Type is stored by integer
                                                continent_ID: contintents.SingleOrDefault(m => m.Name == row.ElementAt(1))?.ID, //Set the continent ID if it can be found
                                                shortName: row.ElementAt(3),
                                                longName: row.ElementAt(4),
                                                fullDescription: row.ElementAt(5),
                                                prayerNeed: float.Parse(row.ElementAt(6).Replace("%", "")),                     // parse percentage by removing %
                                                prayerResource: float.Parse(row.ElementAt(7).Replace("%", "")));

                switch (chunk.Type)                                                                                             // Depending on the type, add rows in the database
                {
                    case 0: //Part - An area of a country
                        Part newPart = Data.CreatePart(ID: Guid.NewGuid(),
                                                        chunk_ID: chunk.ID,
                                                        prayerNeed: chunk.PrayerNeed,
                                                        prayerResource: chunk.PrayerResource);

                        String cntryName = chunk.ShortName.Split('-').First();                                                  // Country name is stored as "Country-Identifier"
                        Country cntry = countryList.Where(m => cntryName == (m.Name!=""?m.Name:m.GivenName)).FirstOrDefault();  // Find a country with that name
                        if(cntry != null)
                        {
                            newPart.Country_ID = cntry.ID;                                                                      // If there is a country with that name, add this part to it
                        }
                        else
                        {                                                                                                       // If there is no country with that name, create one with it's own chunk
                            Chunk cntryChunk = Data.CreateChunk(ID: "B" + (countryList.Count() + 1).ToString().PadLeft(3, '0'),
                                                                type: 1,
                                                                continent_ID: chunk.Continent_ID,
                                                                shortName: cntryName,
                                                                longName: cntryName,
                                                                fullDescription: cntryName,
                                                                prayerNeed: 0.0,
                                                                prayerResource: 0.0);
                            chunkList.Add(cntryChunk);

                            cntry = Data.CreateCountry(ID: Guid.NewGuid(),
                                                        givenName: cntryName,
                                                        chunk_ID: cntryChunk.ID,
                                                        prayerNeed: 0.0,
                                                        prayerResource: 0.0);

                            // If the country can be found in the conversion database, set it's code now
                            String cntryCode = conversions.Where(m => m.CountryName == cntryName).FirstOrDefault()?.Code;
                            if (cntryCode != "" && cntryCode != null)
                            {
                                cntry.Code = cntryCode;
                                cntry.Name = cntry.GivenName;
                            }

                            countryList.Add(cntry);
                            newPart.Country_ID = cntry.ID;
                        }
                        partList.Add(newPart);
                    break;

                    case 1: //Country 
                        Country country = Data.CreateCountry(ID: Guid.NewGuid(),
                                                            givenName: chunk.ShortName,
                                                            chunk_ID: chunk.ID,
                                                            prayerNeed: chunk.PrayerNeed,
                                                            prayerResource: chunk.PrayerResource);

                        // If the country can be found in the conversion database, set it's code now
                        String code = conversions.Where(m => m.CountryName == chunk.ShortName).FirstOrDefault()?.Code;
                        if (code != "" && code != null)
                        {
                            country.Code = code;
                            country.Name = country.GivenName;
                        }
                        countryList.Add(country);
                    break;

                    case 2: //Multi - multiple countries
                        chunk.MultiComplete = false; // tag to allow admin to add countries later
                    break;
                }
                chunkList.Add(chunk);
            }
            Data.SaveData(partList, countryList, chunkList);
            Data.SetCreatedCountryPercents();                                       // If a country was created by parts, it still needs to have it's percentage calculated
            return "success!";
        }

        [HttpPost]
        public String GetCountries() // return all countries that can be identified by code
        {
            // Return all country rows
            List<Country> countries = Data.GetCountries().Where(m => m.Name != " " && m.Name != "").ToList();
            String result = JsonConvert.SerializeObject(countries, Formatting.None,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return result;
        }

        [HttpPost]
        public String GetPrayersFor() // return all prayersFor associations by country code: e.g. (".us", ".ca") VERY LARGE
        {
            // Return all country rows
            List<Tuple<String, String>> list = Data.GetPrayersFor().Select(m => new Tuple<String, String>("."+m.Chunk.Countries.First().Code, "." + m.Chunk1.Countries.First().Code))
                                                                    .Where(m=>m.Item1.Trim() != "." && m.Item2.Trim() != ".").ToList();
            return JsonConvert.SerializeObject(list, Formatting.None,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}