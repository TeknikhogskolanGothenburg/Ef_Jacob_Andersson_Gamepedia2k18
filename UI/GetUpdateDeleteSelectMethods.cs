using GamepediaApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class GetUpdateDeleteSelectMethods
    {
        public static void GetAllPlayers()
        {
            var context = new GamepediaContext();

            var players1 = context.Players.ToList();
            var players2 = context.Players.Where(m => m.NickName.StartsWith("f")).ToList();

            foreach (var player in players1)
            {
                Console.WriteLine(player.FirstName);
            }
        }

        public static void GetLastTournament()
        {
            var context = new GamepediaContext();

            var tournament = context.Tournaments.LastOrDefault(m => m.StartDate.Year == 2016);
            Console.WriteLine(tournament.TournamentName);
        }

        public static void DeleteMany()
        {
            var context = new GamepediaContext();

            string teamName = "fnatic";
            var teams = context.Teams.Where(m => m.Name.StartsWith(teamName)).ToList();
            context.Teams.RemoveRange(teams);
            context.SaveChanges();
        }

        public static void ProjectionLoading2()
        {
            var context = new GamepediaContext();
            var projectedTournament = context.Tournaments.Select(a =>
                    new { a.TournamentName, MapCount = a.Maps.Count })
                    .Where(a => a.MapCount > 1 && a.TournamentName.StartsWith("IEM"))
                    .ToList();

            projectedTournament.ForEach(pa => Console.WriteLine(pa.TournamentName + " has this many maps: " + pa.MapCount));
        }

        public static void DeleteTournamentByCountryId()
        {
            var context = new GamepediaContext();
            var tournament = context.Tournaments
                    .Where(t => t.CountryId == 2)
                    .FirstOrDefault();
            context.Remove(tournament);
            context.SaveChanges();
        }

        public static void DeletePlayerFromTeam()
        {
            var context = new GamepediaContext();
            var teamplayer = context.TeamPlayers
                    .Where(tp => tp.PlayerId == 4 && tp.TeamId == 2)
                    .FirstOrDefault();
            context.Remove(teamplayer);
            context.SaveChanges();
        }

        public static void SelectPlayersWithOrderbyAndStartwith()
        {
            var context = new GamepediaContext();
            var players = context.Players.FromSql("SELECT * FROM Players")
                 .Where(m => m.NickName.StartsWith("f"))
                 .OrderBy(m => m.FirstName)
                 .ToList();
            foreach(var player in players)
            {
                Console.WriteLine(player.LastName);
            }
        }

        public static void SelectUsingStoredProcedure()
        {
            var context = new GamepediaContext();
            string searchMap = "De";
            var maps = context.Maps.FromSql("EXEC FindMapsByName {0}", searchMap).ToList();
            foreach(var map in maps)
            {
                Console.WriteLine(map.Name);
            }
        }

        public static void DisplayCountriesAndMore()
        {
            var context = new GamepediaContext();
            var countries = context.Countries
                .Include(m => m.Players)
                .Include(m => m.Teams)
                .Include(m => m.Tournaments)
                .ToList();

            Console.WriteLine("\n\n\n==============\n");
            foreach (var country in countries)
            {
                Console.WriteLine(country.Name);
                foreach (var player in country.Players)
                {
                    Console.WriteLine("has this player: " + player.NickName);
                }
                foreach (var team in country.Teams)
                {
                    Console.WriteLine("\t and this team: " + team.Name);
                }
                foreach (var tournament in country.Tournaments)
                {
                    Console.WriteLine("\t\t have hosted this tournament: " + tournament.TournamentName + " " + tournament.EndDate.Year);
                    Console.WriteLine("\t\t\t  and the team that won was: " + tournament.TheTeam.Name);
                }
            }
            Console.ReadKey();
        }

        public static void DisplayTeamsAndPlayersAndMore()
        {
            var context = new GamepediaContext();
            var teams = context.Teams
                .Include(m => m.Players)
                    .ThenInclude(ma => ma.Player)
                 .Include(m => m.Tournaments)
                 .ToList();

            Console.WriteLine("\n\n\n=======================\n");
            foreach (var team in teams)
            {
                Console.WriteLine(team.Name);
                if (null != team.Tournaments)
                {
                    Console.WriteLine("Have won this many tournaments: " + team.Tournaments.Count);
                }
                else
                {
                    Console.WriteLine("have not won any tournaments");
                }
                foreach (var player in team.Players)
                {
                    Console.WriteLine("\t" + " with this player: " + player.Player.FirstName + " " + player.Player.LastName + ", NickName: " + player.Player.NickName);
                }
            }
        }

        public static void ProjectionLoading()
        {
            var context = new GamepediaContext();
            var projectedCountry = context.Countries.Select(a =>
                new { a.Name, PlayerCount = a.Players.Count })
                    .Where(a => a.PlayerCount > 0).ToList();

            projectedCountry.ForEach(a => Console.WriteLine(a.Name + " has this many players: " + a.PlayerCount));
        }

        public static void UpdateSingle()
        {
            var context = new GamepediaContext();
            var map = context.Maps.Find(1);
            map.Name = "De_Cbblestone";
            context.SaveChanges();
        }

        public static void UpdateMany()
        {
            var context = new GamepediaContext();
            string tournamentName = "IEM";
            var tournaments = context.Tournaments.Where(m => m.TournamentName.StartsWith(tournamentName)).ToList();
            tournaments.ForEach(m => m.StartDate = new DateTime(2017, 8, 22));
            tournaments.ForEach(m => m.EndDate = new DateTime(2017, 8, 26));
            context.SaveChanges();
        }

        public static void DeleteOne()
        {
            var context = new GamepediaContext();

            var player = context.Players.Find(3);
            context.Players.Remove(player);
            context.SaveChanges();
        }
    }
}
