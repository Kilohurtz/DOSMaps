using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DOSMaps.Models
{
    public class Data
    {
        public static Country GetCountry(Guid id)
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            IEnumerable<Country> countries = from m in dataContext.Countries
                                             where m.ID == id
                                             select m;
                                             
            return countries.First();
        }
        public static List<Country> GetAllCountries()
        {
            DOSMapsDataContext dataContext = new DOSMapsDataContext();
            List<Country> countries = (from country in dataContext.Countries
                                        join chunk in dataContext.Chunks on country.Chunk_ID equals chunk.ID
                                        join part in dataContext.Parts on country.ID equals part.Country_ID
                                        select country).ToList();

            return countries;
        }
    }
}