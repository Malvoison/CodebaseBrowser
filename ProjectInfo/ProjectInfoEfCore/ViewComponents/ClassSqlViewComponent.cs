using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInfoEfCore.Models;


namespace ProjectInfoEfCore.ViewComponents
{
    public class ClassSqlViewComponent : ViewComponent
    {
        private readonly ProjectInfoContext _context;

        public ClassSqlViewComponent(ProjectInfoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? classesId)
        {
            var items = await GetItemsAsync(classesId);
            return View(items);
        }

        private Task<List<ProjectSql>> GetItemsAsync(Guid? classesId)
        {
            var sqlList = from t1 in _context.ClassesSql
                          where t1.ClassesId == classesId
                          select new ProjectSql { LeSql = t1.SqlText };

            return sqlList.ToListAsync();
        }
    }
}
