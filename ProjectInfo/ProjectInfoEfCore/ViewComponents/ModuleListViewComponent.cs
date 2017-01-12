using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInfoEfCore.Models;


namespace ProjectInfoEfCore.ViewComponents
{
    public class ModuleListViewComponent : ViewComponent
    {
        private readonly ProjectInfoContext _context;

        public ModuleListViewComponent(ProjectInfoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? projectsId)
        {
            var items = await GetItemsAsync(projectsId);
            return View(items);
        }

        private Task<List<Modules>> GetItemsAsync(Guid? projectsId)
        {
            var moduleMap = from t2 in _context.ModMap
                            where t2.ProjectsId == projectsId
                            select t2.ModulesId;

            var moduleList = from t1 in _context.Modules
                             where moduleMap.Contains(t1.ModulesId)
                             select t1;

            return moduleList.ToListAsync();
        }
    }
}
