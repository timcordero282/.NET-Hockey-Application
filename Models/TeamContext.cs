using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyProject.Models
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options)
             : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData
              (new Player
              {
                  PlayerID = 1,
                  PlayerName = "Claude Giroux",
                  Position = "Center",
                  Country = "Canada",
                  DateOfBirth = new DateTime(1988, 1, 12),
                  Goals = 21,
                  Assists = 32,
              },
              new Player
              {
                  PlayerID = 2,
                  PlayerName = "Sidney Crosby",
                  Position = "Center",
                  Country = "Canada",
                  DateOfBirth = new DateTime(1987, 8, 7),
                  Goals = 16,
                  Assists = 31
              }
                );

            modelBuilder.Entity<Coach>().HasData
              (new Coach
              {
                  CoachID = 1,
                  CoachName = "Alain Vigneault",
                  Country = "Canada",
                  DateOfBirth = new DateTime(1961, 5, 14),
                  CareerWins = 689
              },
              new Coach
              {
                  CoachID = 2,
                  CoachName = "Mike Sullivan",
                  Country = "US",
                  DateOfBirth = new DateTime(1968, 2, 27),
                  CareerWins = 284
              }

                );

            {
                modelBuilder.Entity<Team>().HasData
                      (new Team
                      {
                          TeamID = 1,
                          TeamName = "Philadelphia Flyers",
                          Conference = "Eastern",
                          Wins = 41,
                          Losses = 21,
                          PlayerID = 1,
                          CoachID = 1
                      },
                      new Team
                      {
                          TeamID = 2,
                          TeamName = "Pittsburgh Penguins",
                          Conference = "Eastern",
                          Wins = 40,
                          Losses = 23,                         
                          PlayerID = 2,
                          CoachID = 2
                          
                      }
                      );
            }

        }
    }
}

