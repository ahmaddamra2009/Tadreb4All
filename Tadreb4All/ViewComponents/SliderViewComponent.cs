using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tadreb4All.Models;

namespace Tadreb4All.ViewComponents
{
    public class SliderViewComponent: ViewComponent
    {
        private readonly TadrebDbContext db;

        public SliderViewComponent(TadrebDbContext _db)
        {
            db = _db;
        }

        public IViewComponentResult Invoke()
        {
            return View( db.Sliders.ToList());
        }

    }
}
