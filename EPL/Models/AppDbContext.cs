using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EPL.Models
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Division> Divisions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Division>().HasData(new Division
            {
                DivisionId = 1,
                Name = "English Premier League"
            });

            modelBuilder.Entity<Team>().HasData(new Team
            {
                TeamId = 1,
                DivisionId = 1,
                Name = "Manchester United",
                Location = "Manchester",
                Stadium = "Old Trafford",

            });

            modelBuilder.Entity<Player>().HasData(new Player
            {
                PlayerId = 1,
                TeamId = 1,
                Name = "David De Gea",
                Position = Position.Goalkeeper,
                ShirtNumber = 1,
                Height = 1.92,
                Weight = 82,
                YearOfBirth = 1990
            });

            modelBuilder.Entity<Player>().HasData(new Player
            {
                PlayerId = 2,
                TeamId = 1,
                Name = "Cristiano Ronaldo",
                Position = Position.Striker,
                ShirtNumber = 7,
                Height = 1.87,
                Weight = 85,
                YearOfBirth = 1985
            });



        }
    }
}

