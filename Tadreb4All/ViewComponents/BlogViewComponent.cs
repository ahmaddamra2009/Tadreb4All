using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tadreb4All.Models;

namespace Tadreb4All.ViewComponents
{
    public class BlogViewComponent:ViewComponent
    {
        private readonly TadrebDbContext db;

        public BlogViewComponent(TadrebDbContext _db)
        {
            db = _db;
        }

        public IViewComponentResult Invoke()
        {
            return View(db.Blogs.ToList().OrderByDescending(x => x.BlogId).Take(3));
        }
    }
}
