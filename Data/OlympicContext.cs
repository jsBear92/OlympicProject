using Microsoft.EntityFrameworkCore;
using OlympicProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Data
{
    public class OlympicContext : DbContext
    {
        public OlympicContext(DbContextOptions<OlympicContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameCompetitor> GameCompetitors { get; set; }
        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Podium> Podia { get; set; }
        public DbSet<EventPic> EventPics { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<GameCompetitor>().ToTable("GameCompetitor");
            modelBuilder.Entity<Competitor>().ToTable("Competitor");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Podium>().ToTable("Podium");
            modelBuilder.Entity<EventPic>().ToTable("EventPic");
            modelBuilder.Entity<Account>().ToTable("Account");

            modelBuilder.Entity<GameCompetitor>().HasKey(gc => new { gc.CompetitorID, gc.GameID });
            modelBuilder.Entity<GameCompetitor>()
                .HasOne(gc => gc.Game)
                .WithMany(g => g.GameCompetitors)
                .HasForeignKey(gc => gc.GameID);
            modelBuilder.Entity<GameCompetitor>()
                .HasOne(gc => gc.Competitor)
                .WithMany(c => c.GameCompetitors)
                .HasForeignKey(gc => gc.CompetitorID);

            modelBuilder.Entity<Account>().HasData(new Account { UserID = 1, UserEmail = "admin@ecu.com", UserPassword = "Admin#1", UserType = 0 });
            modelBuilder.Entity<Account>().HasData(new Account { UserID = 2, UserEmail = "event@ecu.com", UserPassword = "Event#1", UserType = 1 });
        }
    }
}
