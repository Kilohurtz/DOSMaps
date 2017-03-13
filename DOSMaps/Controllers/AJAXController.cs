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
        public String Index()
        {
            return "United States of America";
        }

        [HttpPost]
        public String UpdateSelectedCountry(String ID)
        {
            return Data.GetCountry(ID).Name;
        }
    }
}