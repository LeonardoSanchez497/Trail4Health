using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Trail4Health.Controllers
{
    public class RegTuristController : Controller
    {
           [HttpGet]
        public IActionResult RegTurist()
        {
            return View();
        }
    }
}