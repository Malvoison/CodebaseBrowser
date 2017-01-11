using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInfoEfCore.Models;

namespace ProjectInfoEfCore.ViewComponents
{
    public class ClassListViewComponent : ViewComponent
    {
        private readonly ProjectInfoContext _context;

        public ClassListViewComponent(ProjectInfoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid projectsId)
        {
            var items = await GetItemsAsync(projectsId);
            return View(items);
        }

        private Task<List<Classes>> GetItemsAsync(Guid projectsId)
        {
            var classList = from t1 in _context.Classes
                            let t2s = from t2 in _context.ClassMap
                                      where t2.ProjectsId == projectsId
                                      select t2.ClassesId
                            where t2s.Contains(t1.ClassesId)
                            select t1;

            return classList.ToListAsync();
        }
    }
}
