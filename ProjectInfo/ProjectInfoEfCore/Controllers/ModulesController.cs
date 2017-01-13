using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectInfoEfCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjectInfoEfCore.Controllers
{
    public class ModulesController : Controller
    {
        private ProjectInfoContext _context;

        public ModulesController(ProjectInfoContext context)
        {
            _context = context;
        }

        // GET: /Modules
        public IActionResult Index()
        {
            return View(_context.Modules.ToList());
        }

        //  GET: /Modules/Details/233564D8-E6A5-E611-93D4-005056851664
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mod = await _context.Modules.SingleOrDefaultAsync(m => m.ModulesId == id);
            if (mod == null)
            {
                return NotFound();
            }

            return View(mod);
        }
    }
}
