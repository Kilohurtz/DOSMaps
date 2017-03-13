using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOSMaps.Models
{
    public class Country
    {
        public Guid ID { get; set; }
        public String Name { get; set; }
        public Country(String _Name)
        {
            ID = Guid.NewGuid();
            Name = _Name;
        }
    }
}