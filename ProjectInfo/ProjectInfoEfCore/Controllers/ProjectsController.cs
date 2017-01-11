using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectInfoEfCore.Models;
using Microsoft.AspNetCore.Mvc;


namespace ProjectInfoEfCore.Controllers
{
    public class ProjectsController : Controller
    {
        private ProjectInfoContext _context;

        public ProjectsController(ProjectInfoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Projects.ToList());
        }
    }
}
