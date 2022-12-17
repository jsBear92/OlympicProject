using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    [Authorize(Roles = "Event")]
    public class EventsController : Controller
    {
        private readonly OlympicContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventsController(OlympicContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var viewModel = new EventIndex();
            viewModel.Events = await _context.Events
                .Include(e => e.Game)
                .AsNoTracking()
                .ToListAsync();
            viewModel.Podia = await _context.Podia
                .Include(p => p.Event)
                .Include(p => p.Competitor)
                .AsNoTracking()
                .ToListAsync();
            viewModel.EventPics = await _context.EventPics
                .Include(a => a.Event)
                .AsNoTracking()
                .ToListAsync();
            return View(viewModel);
        }

        // GET: Events/CreateEvent
        public IActionResult CreateEvent()
        {
            ViewData["GameID"] = new SelectList(_context.Games, "GameID", "GameName");
            return View();
        }

        // POST: Events/CreateEvent
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEvent([Bind("EventID,GameID,FeatureEvent,EventVenu,EventDate,EventStartTime,EventEndTime,EventDescription,WorldRecord")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameID"] = new SelectList(_context.Games, "GameID", "GameName", @event.GameID);
            return View(@event);
        }

        // GET: Events/CreatePodium
        public IActionResult CreatePodium()
        {
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "FeatureEvent");
            ViewData["CompetitorID"] = new SelectList(_context.Competitors, "CompetitorID", "CompetitorName");
            return View();
        }

        // POST: Events/CreatePodium
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePodium([Bind("EventID,CompetitorID,CompetitorPosition,CompetitorMedal")] Podium @podium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@podium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "FeatureEvent", @podium.Event.FeatureEvent);
            ViewData["CompetitorID"] = new SelectList(_context.Competitors, "CompetitorID", "CompetitorName", @podium.Competitor.CompetitorName);
            return View(@podium);
        }

        // GET: Events/CreatePhoto
        public IActionResult CreatePhoto()
        {
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "FeatureEvent");
            return View();
        }

        // POST: Events/CreatePhoto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePhoto(EventPicView model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                EventPic eventPic = new EventPic
                {
                    EventID = model.EventID,
                    EventPhoto = uniqueFileName,
                    EventPhotoTags = model.EventPhotoTags,
                };

                _context.Add(eventPic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "FeatureEvent", model.Event.FeatureEvent);
            return View();
        }

        private string UploadedFile(EventPicView model)
        {
            string uniqueFileName = null;

            if (model.EventPhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "eventImage");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.EventPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.EventPhoto.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> DeleteEvent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(g => g.Game)
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("DeleteEvent")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEventConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeletePodium(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @podium = await _context.Podia
                .Include(p => p.Event)
                .Include(p => p.Competitor)
                .FirstOrDefaultAsync(m => m.PodiumID == id);
            if (@podium == null)
            {
                return NotFound();
            }

            return View(@podium);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("DeletePodium")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePodiumConfirmed(int id)
        {
            var @podium = await _context.Podia.FindAsync(id);
            _context.Podia.Remove(@podium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeletePhoto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @photo = await _context.EventPics
                .Include(p => p.Event)
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@photo == null)
            {
                return NotFound();
            }

            return View(@photo);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("DeletePhoto")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePhotoConfirmed(int id)
        {
            var @photo = await _context.EventPics.FindAsync(id);
            _context.EventPics.Remove(@photo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventID == id);
        }
    }
}
