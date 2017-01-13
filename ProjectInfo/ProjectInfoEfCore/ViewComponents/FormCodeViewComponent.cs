using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInfoEfCore.Models;


namespace ProjectInfoEfCore.ViewComponents
{
    public class FormCodeViewComponent : ViewComponent
    {
        private readonly ProjectInfoContext _context;

        public FormCodeViewComponent(ProjectInfoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? formsId)
        {
            var code = from t1 in _context.Forms
                       where t1.FormsId == formsId
                       select t1.FormFileContent;

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
