using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInfoEfCore.Models;


namespace ProjectInfoEfCore.ViewComponents
{
    public class FormListViewComponent : ViewComponent
    {
        private readonly ProjectInfoContext _context;

        public FormListViewComponent(ProjectInfoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? projectsId)
        {
            var items = await GetItemsAsync(projectsId);
            return View(items);
        }

        private Task<List<Forms>> GetItemsAsync(Guid? projectsId)
        {
            var formMap = from t2 in _context.FormsMap
                          where t2.ProjectsId == projectsId
                          select t2.FormsId;

            var formList = from t1 in _context.Forms
                           where formMap.Contains(t1.FormsId)
                           select t1;

            return formList.ToListAsync();
        }
    }
}
