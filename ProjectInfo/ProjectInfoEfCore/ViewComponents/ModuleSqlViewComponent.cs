using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInfoEfCore.Models;

namespace ProjectInfoEfCore.ViewComponents
{
    public class ModuleSqlViewComponent : ViewComponent
    {
        private readonly ProjectInfoContext _context;

        public ModuleSqlViewComponent(ProjectInfoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? modulesId)
        {
            var items = await GetItemsAsync(modulesId);
            return View(items);
        }

        private Task<List<ProjectSql>> GetItemsAsync(Guid? modulesId)
        {
            var sqlList = from t1 in _context.ModulesSql
                          where t1.ModulesId == modulesId
                          select new ProjectSql { LeSql = t1.SqlText };

            return sqlList.ToListAsync();            
        }
    }
}
