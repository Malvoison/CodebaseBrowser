using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInfoEfCore.Models;


namespace ProjectInfoEfCore.ViewComponents
{
    public class ReferenceListViewComponent : ViewComponent
    {
        private readonly ProjectInfoContext _context;

        public ReferenceListViewComponent(ProjectInfoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult>  InvokeAsync(Guid? projectsId)
        {
            var items = await GetItemsAsync(projectsId);
            return View(items);
        }

        private Task<List<Referencez>> GetItemsAsync(Guid? projectsId)
        {
            var refMap = from t2 in _context.RefMap
                         where t2.ProjectsId == projectsId
                         select t2.ReferencezId;

            var refList = from t1 in _context.Referencez
                          where refMap.Contains(t1.ReferencezId)
                          select t1;

            return refList.ToListAsync();
        }
    }
}
