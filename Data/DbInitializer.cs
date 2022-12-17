using OlympicProject.Controllers;
using OlympicProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(OlympicContext context)
        {
            context.Database.EnsureCreated();

            if (context.Games.Any())
            {
                return;
            }

            var games = new Game[]
            {
                new Game{GameCode="ABCD123",GameName="Perth Olympic",GameDurationInHours="8",GameDescription="Perth Summer Olympic",GameRulesBooklet="4040322c-d714-4c78-9149-8a7227e0a757_puppy-5632005_1280"}
            };
            foreach (Game g in games)
            {
                context.Games.Add(g);
            }
            context.SaveChanges();

            var competitor = new Competitor[]
            {
                new Competitor{CompetitorSalutation="Hi",CompetitorName="James",CompetitorDoB=DateTime.Parse("10/9/1995 12:00:00 AM"),CompetitorEmail ="abcd@gmail.com",CompetitorDescription="New Rising Star",CompetitorCountry=0,CompetitorGender=0,CompetitorContactNo="1234567890",CompetitorWebsite="No",CompetitorPhoto="human1.jpg"},
                new Competitor{CompetitorSalutation="Get Gold",CompetitorName="John",CompetitorDoB=DateTime.Parse("10/21/1997 12:00:00 AM"),CompetitorEmail ="a1s2d3@gmail.com",CompetitorDescription="New Rising Star",CompetitorCountry=0,CompetitorGender=0,CompetitorContactNo="1234567890",CompetitorWebsite="No",CompetitorPhoto="human1.jpg"}
            };
            foreach (Competitor c in competitor)
            {
                context.Competitors.Add(c);
            }
            context.SaveChanges();

            var events = new Event[]
            {
                new Event{GameID=1,FeatureEvent="Cycling",EventVenu="PerthRacing",EventDate=DateTime.Parse("10/20/2020 12:00:00 AM"),EventStartTime=DateTime.Parse("10/20/2020 5:00:00 PM"),EventEndTime=DateTime.Parse("10/20/2020 12:28:00 PM"),EventDescription="Cylists Race using oval stadium",WorldRecord="James"},
                new Event{GameID=1,FeatureEvent="Running",EventVenu="Perth Optus Stadium",EventDate=DateTime.Parse("10/21/2020 12:00:00 AM"),EventStartTime=DateTime.Parse("10/21/2020 1:00:00 PM"),EventEndTime=DateTime.Parse("10/21/2020 2:10:00 PM"),EventDescription="Atheles run 200m, 2000m",WorldRecord="John"}
            };
            foreach (Event e in events)
            {
                context.Events.Add(e);
            }
            context.SaveChanges();

            var podium = new Podium[]
            {
                new Podium{EventID=1,CompetitorID=1,CompetitorPosition="1st",CompetitorMedal=0}
            };
            foreach (Podium p in podium)
            {
                context.Podia.Add(p);
            }
            context.SaveChanges();

            var eventPic = new EventPic[]
            {
                new EventPic{EventID=1,EventPhoto="cycling.jpg",EventPhotoTags="Cycling"}
            };
            foreach (EventPic ep in eventPic)
            {
                context.EventPics.Add(ep);
            }
            context.SaveChanges();
        }
    }
}
