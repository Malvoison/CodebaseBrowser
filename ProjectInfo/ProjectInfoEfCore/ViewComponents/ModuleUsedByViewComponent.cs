using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInfoEfCore.Models;


namespace ProjectInfoEfCore.ViewComponents
{
    public class ModuleUsedByViewComponent : ViewComponent
    {
        private readonly ProjectInfoContext _context;

        public ModuleUsedByViewComponent(ProjectInfoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? modulesId)
        {
            var items = await GetItemsAsync(modulesId);
            return View(items);
        }

        private Task<List<Projects>> GetItemsAsync(Guid? modulesId)
        {
            var projMap = from t2 in _context.ModMap
                          where t2.ModulesId == modulesId
                          select t2.ProjectsId;

            var projList = from t1 in _context.Projects
                           where projMap.Contains(t1.ProjectsId)
                           select t1;

            return projList.ToListAsync();
        }
    }
}
