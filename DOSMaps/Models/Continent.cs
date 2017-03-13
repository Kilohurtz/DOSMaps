using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOSMaps.Models
{
    public class Continent
    {
        public Guid ID { get; set; }
        public String Name { get; set; }
        public Continent(String _Name)
        {
            ID = Guid.NewGuid();
            Name = _Name;
        }
    }
}