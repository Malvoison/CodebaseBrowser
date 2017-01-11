using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectInfoEfCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjectInfoEfCore.Controllers
{
    public class ProjectsController : Controller
    {
        private ProjectInfoContext _context;

        public ProjectsController(ProjectInfoContext context)
        {
            _context = context;
        }

        //  GET:  Projects
        public IActionResult Index()
        {
            return View(_context.Projects.ToList());
        }

        //  GET:  Projects/Details/FE3464D8-E6A5-E611-93D4-005056851664
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectsId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }
    }
}
