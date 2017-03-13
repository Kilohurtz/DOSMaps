using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOSMaps.Models
{
    public class Church
    {
        public Guid ID { get; set; }
        public String Name { get; set;}
        //public String Name { get; set; }
        //public String Name { get; set; }

        public Church(String _Name)
        {
            ID = Guid.NewGuid();
            Name = _Name;
        }
    }
}