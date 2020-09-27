using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tadreb4All.Models;

namespace Tadreb4All.ViewComponents
{
    public class InstructorViewComponent:ViewComponent
    {
        private readonly TadrebDbContext db;

        public InstructorViewComponent(TadrebDbContext _db)
        {
            db = _db;
        }

        public IViewComponentResult Invoke()
        {
            return View(db.Instructors.ToList().OrderByDescending(x => x.InstructorId).Take(6));
        }
    }
}
