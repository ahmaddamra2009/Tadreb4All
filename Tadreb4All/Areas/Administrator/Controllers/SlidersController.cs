using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tadreb4All.Models;

namespace Tadreb4All.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SlidersController : Controller
    {
        private readonly TadrebDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public SlidersController(TadrebDbContext context, IHostingEnvironment _hostingEnvironment)
        {
            _context = context;
            hostingEnvironment = _hostingEnvironment;
        }

        // GET: Administrator/Sliders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sliders.ToListAsync());
        }

        // GET: Administrator/Sliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders
                .FirstOrDefaultAsync(m => m.SliderId == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // GET: Administrator/Sliders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (ModelState.IsValid)
            {
                var Myfiles = HttpContext.Request.Form.Files;
                foreach (var Image in Myfiles)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;
                        var upload = Path.Combine(hostingEnvironment.WebRootPath, "Sliders\\img");
                        if (file.Length > 0)
                        {
                         // sdfsdafsdf56a54sdf564asdf654asd6d5df.jpg
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            using (var fileStream = new FileStream(Path.Combine(upload, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                slider.SliderImg = "~/Sliders/img/" + fileName;
                            }
                        }
                    }
                }
                _context.Sliders.Add(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Sliders");

            }
            return View(slider);
        }

        // GET: Administrator/Sliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        // POST: Administrator/Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SliderId,SliderTitle,SubTitle,Location,DiscountPer,Cost,SliderImg,SliderDesc,IsActive")] Slider slider)
        {
            if (id != slider.SliderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderExists(slider.SliderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        // GET: Administrator/Sliders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders
                .FirstOrDefaultAsync(m => m.SliderId == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // POST: Administrator/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderExists(int id)
        {
            return _context.Sliders.Any(e => e.SliderId == id);
        }
    }
}
