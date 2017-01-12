using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectInfoEfCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjectInfoEfCore.Controllers
{
    public class ClassesController : Controller
    {
        private ProjectInfoContext _context;

        public ClassesController(ProjectInfoContext context)
        {
            _context = context;
        }

        // GET: /Classes
        public IActionResult Index()
        {
            return View(_context.Classes.ToList());
        }

        //  GET: Classes/Details/2B3564D8-E6A5-E611-93D4-005056851664
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cls = await _context.Classes.SingleOrDefaultAsync(m => m.ClassesId == id);
            if (cls == null)
            {
                return NotFound();
            }

            return View(cls);
        }
    }
}
