using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInfoEfCore.Models;


namespace ProjectInfoEfCore.ViewComponents
{
    public class ModuleCodeViewComponent : ViewComponent
    {
        private readonly ProjectInfoContext _context;

        public ModuleCodeViewComponent(ProjectInfoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? modulesId)
        {
            var code = from t1 in _context.Modules
                       where t1.ModulesId == modulesId
                       select t1.ModuleFileContent;

            byte[] arrCode = await code.FirstOrDefaultAsync();

            ProjectCode pc = new ProjectCode();
            if (arrCode != null)
            {
                pc.LeCode = System.Text.Encoding.ASCII.GetString(arrCode);
            }
            else
            {
                pc.LeCode = "Code not available";
            }

            return View(pc);
        }
    }
}
