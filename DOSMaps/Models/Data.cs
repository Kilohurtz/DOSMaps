using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DOSMaps.Models
{
    public class Data
    {
        public static Country GetCountry(String id)
        {
            DOSMapsDataContext dmdc = new DOSMapsDataContext();
            IEnumerable<Country> countries = from m in dmdc.Countries
                                             where m.ID == id
                                             select m;
                                             
            return countries.First();
        }
    }
}