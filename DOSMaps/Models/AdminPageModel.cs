using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOSMaps.Models
{
    public class AdminPageModel
    {
        public List<Chunk> Multis = new List<Chunk>();
        public List<Country> UnnamedCountries = new List<Country>();
        public AdminPageModel(List<Chunk> multis, List<Country> unnamedCountries)
        {
            Multis = multis;
            UnnamedCountries = unnamedCountries;
        }
    }
}