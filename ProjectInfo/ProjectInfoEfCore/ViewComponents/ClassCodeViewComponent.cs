﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInfoEfCore.Models;


namespace ProjectInfoEfCore.ViewComponents
{
    public class ClassCodeViewComponent : ViewComponent
    {
        private readonly ProjectInfoContext _context;

        public ClassCodeViewComponent(ProjectInfoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? classesId)
        {
            var code = from t1 in _context.Classes
                       where t1.ClassesId == classesId
                       select t1.ClassFileContent;

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
