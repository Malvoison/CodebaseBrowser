using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInfoEfCore.Models;


namespace ProjectInfoEfCore.ViewComponents
{
    public class ObjectRefListViewComponent : ViewComponent
    {
        private readonly ProjectInfoContext _context;

        public ObjectRefListViewComponent(ProjectInfoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? projectsId)
        {
            var items = await GetItemsAsync(projectsId);
            return View(items);            
        }

        private Task<List<ObjectRefs>> GetItemsAsync(Guid? projectsId)
        {
            var refMap = from t2 in _context.ObjRefMap
                         where t2.ProjectsId == projectsId
                         select t2.ObjectRefsId;

            var refList = from t1 in _context.ObjectRefs
                          where refMap.Contains(t1.ObjectRefsId)
                          select t1;

            return refList.ToListAsync();
        }
    }
}
