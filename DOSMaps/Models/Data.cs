using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DOSMaps.Models
{
    public class Data
    {
        public static void SaveMulti(String ID, List<Chunk> countryChunks, List<Country> countries)
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            dataContext.Countries.InsertAllOnSubmit(countries);
            dataContext.Chunks.InsertAllOnSubmit(countryChunks);
            Chunk modified = (from chunk in dataContext.Chunks
                                where chunk.ID == ID
                                select chunk).SingleOrDefault();
            modified.MultiComplete = true;
            dataContext.SubmitChanges();
        }

        public static void SaveCountryName(Guid ID, String countryName, String countryCode)
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            Country modified = (from country in dataContext.Countries
                              where country.ID == ID
                              select country).SingleOrDefault();
            modified.Name = countryName;
            modified.Code = countryCode;
            dataContext.SubmitChanges();
        }

        public static void SaveConversions(List<Conversion> conversions)
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            dataContext.Conversions.InsertAllOnSubmit(conversions);
            dataContext.SubmitChanges();
        }

        public static void SavePrayersFor(List<PrayersFor> prayersFor)
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            dataContext.PrayersFors.InsertAllOnSubmit(prayersFor);
            dataContext.SubmitChanges();
        }

        public static void SaveData(List<Part> parts, List<Country> countries, List<Chunk> chunks)
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            dataContext.Parts.InsertAllOnSubmit(parts);
            dataContext.Countries.InsertAllOnSubmit(countries);
            dataContext.Chunks.InsertAllOnSubmit(chunks);
            dataContext.SubmitChanges();
        }

        public static void SetCreatedCountryPercents()
        {
            // Set countries' percentages to the average of it's parts percentages
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            List<Country> countries = (from country in dataContext.Countries
                                       where country.PrayerNeed == 0.0
                                       join chunk in dataContext.Chunks on country.Chunk_ID equals chunk.ID
                                       join part in dataContext.Parts on country.ID equals part.Country_ID
                                       select country).ToList();

            foreach(Country country in countries)
            {
                double needSum = 0.0;
                double resourceSum = 0.0;
                foreach(Part part in country.Parts)
                {
                    needSum += part.PrayerNeed;
                    resourceSum += part.PrayerResource;
                }
                country.PrayerNeed = needSum / country.Parts.Count();
                country.PrayerResource = resourceSum / country.Parts.Count();
                country.Chunk.PrayerNeed = country.PrayerNeed;
                country.Chunk.PrayerResource = country.PrayerResource;
            }
            dataContext.SubmitChanges();
        }

        public static List<Conversion> GetConversions()
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            List<Conversion> conversions = (from conversion in dataContext.Conversions
                                            select conversion).ToList();
            return conversions;
        }

        public static List<Continent> GetContinents()
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            List<Continent> continents = (from continent in dataContext.Continents
                                            select continent).ToList();
            return continents;
        }

        public static List<Country> GetCountries()
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            List<Country> countries = (from country in dataContext.Countries
                                        join chunk in dataContext.Chunks on country.Chunk_ID equals chunk.ID
                                        join part in dataContext.Parts on country.ID equals part.Country_ID into parts
                                            from part in parts.DefaultIfEmpty()
                                        select country).Distinct().ToList();

            return countries;
        }

        public static List<Chunk> GetMultis()
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            List<Chunk> multis = (from chunk in dataContext.Chunks
                                  where chunk.Type == 2
                                  join country in dataContext.Countries on chunk.ID equals country.MultiChunk_ID into countries
                                        from country in countries.DefaultIfEmpty()
                                  select chunk).ToList();
            return multis;
        }

        public static List<Chunk> GetChunks()
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            List<Chunk> result = (from chunk in dataContext.Chunks
                                  select chunk).ToList();
            return result;
        }

        public static List<Part> GetParts()
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            List<Part> result = (from part in dataContext.Parts
                                  select part).ToList();
            return result;
        }

        public static List<PrayersFor> GetPrayersFor()
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            List<PrayersFor> result = (from prayersFor in dataContext.PrayersFors
                                 select prayersFor).ToList();
            return result;
        }

        public static Chunk GetChunk(String ID)
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            Chunk result = (from chunk in dataContext.Chunks
                            where chunk.ID == ID
                            select chunk).SingleOrDefault();
            return result;
        }

        public static Country GetCountry(Guid ID)
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            Country result = (from country in dataContext.Countries
                            where country.ID == ID
                            select country).SingleOrDefault();
            return result;
        }

        public static Chunk CreateChunk(String ID, int type, Guid? continent_ID, String shortName, String longName, String fullDescription, double prayerNeed, double prayerResource)
        {
            // Custom constructor for a generated class
            Chunk c = new Chunk();
            c.ID = ID;
            c.Type = type;
            if (continent_ID.HasValue) {
                c.Continent_ID = continent_ID.Value;
            }
            c.ShortName = shortName;
            c.LongName = longName.Replace("\"",""); // Remove quotes " in chunk names
            c.FullDescription = fullDescription.Replace("\"", "");
            c.PrayerNeed = prayerNeed;
            c.PrayerResource = prayerResource;

            return c;
        }

        public static Country CreateCountry(Guid ID, String chunk_ID, String givenName, double prayerNeed, double prayerResource, String multiChunk_ID = null)
        {
            // Custom constructor for a generated class
            Country country = new Country();
            country.ID = ID;
            country.Chunk_ID = chunk_ID;
            country.GivenName = givenName;
            country.Name = "";
            country.Code = "";
            country.PrayerNeed = prayerNeed;
            country.PrayerResource = prayerResource;
            country.MultiChunk_ID = multiChunk_ID;

            return country;
        }

        public static Part CreatePart(Guid ID, String chunk_ID, double prayerNeed, double prayerResource)
        {
            // Custom constructor for a generated class
            Part p = new Part();
            p.ID = ID;
            p.Chunk_ID = chunk_ID;
            p.PrayerNeed = prayerNeed;
            p.PrayerResource = prayerResource;

            return p;
        }
    }
}
