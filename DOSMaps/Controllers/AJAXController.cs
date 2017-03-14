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
        [HttpPost]
        public String GetAllCountries()
        {
            
            return JsonConvert.SerializeObject(Data.GetAllCountries(), Formatting.None, 
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpPost]
        public String GetSelectedCountry(Guid ID)
        {
            return JsonConvert.SerializeObject(Data.GetCountry(ID));
        }
    }
}