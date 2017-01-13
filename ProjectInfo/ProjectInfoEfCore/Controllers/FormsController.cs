using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectInfoEfCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjectInfoEfCore.Controllers
{
    public class FormsController : Controller
    {
        private ProjectInfoContext _context;

        public FormsController(ProjectInfoContext context)
        {
            _context = context;
        }

        // GET: /Forms
        public IActionResult Index()
        {
            return View(_context.Forms.ToList());
        }

        // GET: /Forms/Details/613564D8-E6A5-E611-93D4-005056851664
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frm = await _context.Forms.SingleOrDefaultAsync(f => f.FormsId == id);
            if (frm == null)
            {
                return NotFound();
            }

            return View(frm);
        }
    }
}
