using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInfoEfCore.Models;


namespace ProjectInfoEfCore.ViewComponents
{
    public class ClassUsedByViewComponent : ViewComponent
    {
        private readonly ProjectInfoContext _context;

        public ClassUsedByViewComponent(ProjectInfoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? classesId)
        {
            var items = await GetItemsAsync(classesId);
            return View(items);
        }

        private Task<List<Projects>> GetItemsAsync(Guid? classesId)
        {
            var projMap = from t2 in _context.ClassMap
                          where t2.ClassesId == classesId
                          select t2.ProjectsId;

            var projList = from t1 in _context.Projects
                           where projMap.Contains(t1.ProjectsId)
                           select t1;

            return projList.ToListAsync();
        }
    }
}
