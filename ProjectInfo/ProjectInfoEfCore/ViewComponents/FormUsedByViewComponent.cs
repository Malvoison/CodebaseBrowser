using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInfoEfCore.Models;


namespace ProjectInfoEfCore.ViewComponents
{
    public class FormUsedByViewComponent : ViewComponent
    {
        private readonly ProjectInfoContext _context;

        public FormUsedByViewComponent(ProjectInfoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? formsId)
        {
            var items = await GetItemsAsync(formsId);
            return View(items);
        }

        private Task<List<Projects>> GetItemsAsync(Guid? formsId)
        {
            var projMap = from t2 in _context.FormsMap
                          where t2.FormsId == formsId
                          select t2.ProjectsId;

            var projList = from t1 in _context.Projects
                           where projMap.Contains(t1.ProjectsId)
                           select t1;

            return projList.ToListAsync();
        }
    }
}
