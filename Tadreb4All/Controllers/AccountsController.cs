using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tadreb4All.Models;

namespace Tadreb4All.Controllers
{
    public class AccountsController : Controller
    {
        public readonly TadrebDbContext db;
        private readonly IHostingEnvironment hostingEnvironment;
        public AccountsController(TadrebDbContext _db,IHostingEnvironment _hostingEnvironment)
        {
            db = _db;
            hostingEnvironment = _hostingEnvironment;
        }
        public IActionResult Register()
        {
            ViewData["RoleId"] = new SelectList(db.Roles.ToList(), "RoleId", "RoleName");
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                var Myfiles = HttpContext.Request.Form.Files;
                foreach (var Image in Myfiles)
                {
                    if (Image!=null && Image.Length>0)
                    {
                        var file = Image;
                        var upload = Path.Combine(hostingEnvironment.WebRootPath, "Users\\img");
                        if (file.Length>0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("-","") + Path.GetExtension(file.FileName);
                            using (var fileStream = new FileStream(Path.Combine(upload, fileName), FileMode.Create))
                            {
                              await  file.CopyToAsync(fileStream);
                                user.UserImg = "~/Users/img/" + fileName;
                            }
                        }
                    }
                }
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Login");

            }

            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(User user)
        {
            var chkUser = db.Users.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password));
            if (chkUser.Any())
            {
                if (chkUser.SingleOrDefault().IsActive==true)
                {
                    HttpContext.Session.SetString("name", chkUser.SingleOrDefault().UserName.ToString());
                    HttpContext.Session.SetString("img", chkUser.SingleOrDefault().UserImg.ToString());
                    return RedirectToAction("Index", "Dashboard", new {area= "Administrator" });
                }
                else
                {
                    ViewBag.Error = "Your Account is locked contact admin";
                    return View(user);
                }
            }
            else
            {
                ViewBag.Error = "Check User Name / Password";

                return View(user);
            }
           
        }

        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Accounts");

        }
    }
}
