using DOSMaps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOSMaps.Controllers
{
    public class AJAXController : Controller
    {
        [HttpPost]
        public List<Country> GetCountries()
        {
            return Data.GetAllCountries();
        }

        [HttpPost]
        public Country GetSelectedCountry(Guid ID)
        {
            return Data.GetCountry(ID);
        }
    }
}