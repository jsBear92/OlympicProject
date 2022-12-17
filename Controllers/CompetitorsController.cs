using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OlympicProject.Data;
using OlympicProject.Models;
using OlympicProject.Models.ViewModels;

namespace OlympicProject.Controllers
{

    [Authorize(Roles = "Admin")]
    public class CompetitorsController : Controller
    {
        private readonly OlympicContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CompetitorsController(OlympicContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
        }

        // GET: Competitors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Competitors.ToListAsync());
        }

        // GET: Competitors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitor = await _context.Competitors
                .FirstOrDefaultAsync(m => m.CompetitorID == id);
            if (competitor == null)
            {
                return NotFound();
            }

            return View(competitor);
        }

        // GET: Competitors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Competitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompetitorView model)
        {
            
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Competitor competitor = new Competitor
                {
                    CompetitorSalutation = model.CompetitorSalutation,
                    CompetitorName = model.CompetitorName,
                    CompetitorDoB = model.CompetitorDoB,
                    CompetitorEmail = model.CompetitorEmail,
                    CompetitorDescription = model.CompetitorDescription,
                    CompetitorCountry = model.CompetitorCountry,
                    CompetitorGender = model.CompetitorGender,
                    CompetitorContactNo = model.CompetitorContactNo,
                    CompetitorWebsite = model.CompetitorWebsite,
                    CompetitorPhoto = uniqueFileName,

                };

                _context.Add(competitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private string UploadedFile(CompetitorView model)
        {
            string uniqueFileName = null;

            if (model.CompetitorPhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "competitorImage");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CompetitorPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CompetitorPhoto.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        // GET: Competitors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null)
            {
                return NotFound();
            }
            return View(competitor);
        }

        // POST: Competitors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompetitorID,CompetitorSalutation,CompetitorName,CompetitorDoB,CompetitorEmail,CompetitorDescription,CompetitorCountry,CompetitorGender,CompetitorContactNo,CompetitorWebsite,CompetitorPhoto")] Competitor competitor)
        {
            if (id != competitor.CompetitorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competitor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetitorExists(competitor.CompetitorID))
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
            return View(competitor);
        }

        // GET: Competitors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitor = await _context.Competitors
                .FirstOrDefaultAsync(m => m.CompetitorID == id);
            if (competitor == null)
            {
                return NotFound();
            }

            return View(competitor);
        }

        // POST: Competitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competitor = await _context.Competitors.FindAsync(id);
            _context.Competitors.Remove(competitor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetitorExists(int id)
        {
            return _context.Competitors.Any(e => e.CompetitorID == id);
        }
    }
}
