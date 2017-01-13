using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInfoEfCore.Models;


namespace ProjectInfoEfCore.ViewComponents
{
    public class FormSqlViewComponent : ViewComponent
    {
        private readonly ProjectInfoContext _context;

        public FormSqlViewComponent(ProjectInfoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? formsId)
        {
            var items = await GetItemsAsync(formsId);
            return View(items);
        }

        private Task<List<ProjectSql>> GetItemsAsync(Guid? formsId)
        {
            var sqlList = from t1 in _context.FormsSql
                          where t1.FormsId == formsId
                          select new ProjectSql { LeSql = t1.SqlText };

            return sqlList.ToListAsync();
        }
    }
}
