using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using OlympicProject.Data;
using OlympicProject.Models;
using OlympicProject.Models.ViewModels;

namespace OlympicProject.Controllers
{
    [Authorize(Roles = "Event")]
    public class ReportController : Controller
    {
        private readonly OlympicContext _context;

        public ReportController(OlympicContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            /*
            var viewModel = new CollectingReport().ToString();
            viewModel.Competitors = await _context.Competitors
                .Include(r => r.Podia)
                .Include(r => r.Podia)
                    .ThenInclude(r => r.Event)
                .AsNoTracking()
                .ToListAsync();


            var goldCount = _context.Podia
                        .FirstOrDefault(g => g.Competitor.CompetitorCountry)
                        .Select(g => g.c)
                        .Count();

            ViewBag.Gold = goldCount;
            */

            var medalCount = (from c in _context.Competitors.AsEnumerable()
                             join g in _context.Podia.AsEnumerable()
                             on c.CompetitorID equals g.CompetitorID
                             group new { g, c} by new { g.CompetitorMedal, c.CompetitorCountry} into a
                             select
                             new
                             {
                                 Country = a.Key.CompetitorCountry,
                                 Gold = a.Count(x => x.g.CompetitorMedal.ToString() == "Gold"),
                                 Silver = a.Count(x => x.g.CompetitorMedal.ToString() == "Silver"),
                                 Bronze = a.Count(x => x.g.CompetitorMedal.ToString()== "Bronze"),
                                 Count = a.Count()
                             }).ToList();

            List<CountryMedal> medalList = new List<CountryMedal>();
            for (int i = 0; i < medalCount.ToList().Count; i++)
            {
                medalList.Add(new CountryMedal 
                { 
                    CountryName = medalCount[i].Country.ToString(), 
                    GoldCount = medalCount[i].Gold, 
                    SilverCount = medalCount[i].Silver,
                    BronzeCount = medalCount[i].Bronze,
                    TotalCount = medalCount[i].Count
                });
            }

            return View(medalList);
        }
    }
}
