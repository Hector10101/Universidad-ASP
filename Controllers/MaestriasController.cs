using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Universidad_ASP.Controllers
{
    public class MaestriasController : Controller
    {
        public IActionResult IndexMaestrias()
        {
            return View();
        }
    }
}