using GamepediaApp.Data;
using GamepediaApp.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class AddTableDataMethods
    {
        public static void AddCountry()
        {
            var context = new GamepediaContext();
            byte[] image1 = File.ReadAllBytes(@"C:\Users\Jacob\source\repos\myGamepedia\UI\Images\Swedishflag.jpg");
            byte[] image2 = File.ReadAllBytes(@"C:\Users\Jacob\source\repos\myGamepedia\UI\Images\Canadaflag.jpg");

            Country country1 = new Country { Name = "Sweden", CountryCode = "SE", FlagImage = image1 };
            Country country2 = new Country { Name = "Canada", CountryCode = "CA", FlagImage = image2 };

            context.Countries.AddRange(country1, country2);
            context.SaveChanges();
        }

        public static void AddPlayersToTeam()
        {
            var context = new GamepediaContext();

            var team = context.Teams.Find(2);
            var players = context.Players.ToList();
            foreach (var player in players)
            {
                if (player.FirstName == "Freddy" || player.FirstName == "Jesper")
                {
                    context.TeamPlayers.Add(new TeamPlayer { TeamId = team.Id, PlayerId = player.Id });
                }
            }
            context.SaveChanges();
        }

        public static void AddTournamentMap()
        {
            var context = new GamepediaContext();

            var map = context.Maps.Find(5);
            var tournament = context.Tournaments.Find(5);
            context.Add(new TournamentMap { Map = map, Tournament = tournament });
            context.SaveChanges();
        }

        public static void AddTeamPlayers()
        {
            var context = new GamepediaContext();

            var player = context.Players.Find(2);
            var team = context.Teams.Find(2);
            context.Add(new TeamPlayer { Team = team, Player = player });
            context.SaveChanges();
        }

        public static void AddTournament()
        {
            var context = new GamepediaContext();

            Tournament tournament = new Tournament
            {
                Tier = "Major",
                GameName = "Counter-Strike",
                TournamentName = "DreamHack Open",
                StartDate = new DateTime(2017, 8, 22),
                EndDate = new DateTime(2017, 8, 28),
                PriceMoney = 1000000,
                TeamId = 1,
                CountryId = 1
            };
            context.Tournaments.Add(tournament);
            context.SaveChanges();
        }

        public static void AddMap()
        {
            var context = new GamepediaContext();

            Map map = new Map { Name = "De_Inferno", Launch = new DateTime(1998, 6, 12) };
            context.Maps.Add(map);
            context.SaveChanges();
        }

        public static void AddPlayer()
        {
            var context = new GamepediaContext();

            Player player1 = new Player
            {
                FirstName = "Patrik",
                LastName = "Lindberg",
                BirthDate = new DateTime(1988, 5, 15),
                NickName = "f0rest",
                Role = "Rifler",
                Status = "Active",
                CountryId = 1
            };

            context.Players.Add(player1);
            context.SaveChanges();
        }

        public static void AddTeam()
        {
            var context = new GamepediaContext();
            byte[] image1 = File.ReadAllBytes(@"C:\Users\Jacob\source\repos\myGamepedia\UI\Images\NiPlogo.jpg");
            byte[] image2 = File.ReadAllBytes(@"C:\Users\Jacob\source\repos\myGamepedia\UI\Images\fnatic-logo-font.png");

            Team team1 = new Team();
            team1.Name = "Ninjas In Pyjamas";
            team1.Description = "Counter-Strike Team";
            team1.TeamLogo = image1;
            team1.Founded = new DateTime(1999, 6, 21);
            team1.CountryId = 1;

            Team team2 = new Team();
            team2.Name = "Fnatic";
            team2.Description = "Counter-Strike Team";
            team2.TeamLogo = image2;
            team2.Founded = new DateTime(1995, 10, 22);
            team2.CountryId = 1;

            context.Teams.AddRange(team1, team2);
            context.SaveChanges();
        }
    }
}
