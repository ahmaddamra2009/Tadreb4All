using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tadreb4All.Models;

namespace Tadreb4All.Controllers
{
    public class HomeController : Controller
    {
        //  TadrebDbContext db = new TadrebDbContext();
        public readonly TadrebDbContext db;
        public HomeController(TadrebDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View(db.Courses.ToList()); 
        }
       
    }
}
