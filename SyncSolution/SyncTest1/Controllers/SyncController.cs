using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SyncTest1.Controllers
{
    public class SyncController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}