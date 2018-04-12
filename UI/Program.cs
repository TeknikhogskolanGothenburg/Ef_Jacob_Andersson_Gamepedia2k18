using GamepediaApp.Data;
using GamepediaApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddTableDataMethods.AddCountry();
            //AddTableDataMethods.AddTeam();
            //AddTableDataMethods.AddPlayer();
            //AddTableDataMethods.AddMap();
            //AddTableDataMethods.AddTournament();
            //AddTableDataMethods.AddTeamPlayers();
            //AddTableDataMethods.AddTournamentMap();
            //AddTableDataMethods.AddPlayersToTeam();

            //GetUpdateDeleteSelectMethods.GetAllPlayers();
            //GetUpdateDeleteSelectMethods.GetLastTournament();
            //GetUpdateDeleteSelectMethods.DeleteOne();
            //GetUpdateDeleteSelectMethods.DeleteMany();
            //GetUpdateDeleteSelectMethods.UpdateMany();
            //GetUpdateDeleteSelectMethods.UpdateSingle();
            //GetUpdateDeleteSelectMethods.ProjectionLoading();
            //GetUpdateDeleteSelectMethods.ProjectionLoading2();
            //GetUpdateDeleteSelectMethods.DisplayTeamsAndPlayersAndMore();
            //GetUpdateDeleteSelectMethods.DisplayCountriesAndMore();
            //GetUpdateDeleteSelectMethods.SelectUsingStoredProcedure();
            //GetUpdateDeleteSelectMethods.SelectPlayersWithOrderbyAndStartwith();
            //GetUpdateDeleteSelectMethods.DeletePlayerFromTeam();
            GetUpdateDeleteSelectMethods.DeleteTournamentByCountryId();


            //var result = SelectTeamAndPlayersWithAsync();
            //Console.WriteLine("Waiting....");
            //foreach(var team in result.Result)
            //{
            //    Console.WriteLine(team.Name);
            //    foreach(var player in team.Players)
            //    {
            //        Console.WriteLine("\t " + player.Player.NickName);
            //    }
            //}

            //var result = SelectTournamentAndMapsWithAsync();
            //Console.WriteLine("Waiting....");
            //foreach(var tournament in result.Result)
            //{
            //    Console.WriteLine("\n" + tournament.TournamentName);
            //    foreach(var map in tournament.Maps)
            //    {
            //        Console.WriteLine("\t" + map.Map.Name);
            //    }
            //}

            //Jag valde att använda Async,
            //det känns som det är det som dom flesta använder,
            //och det var lättare att förstå hur man skulle använda det jämnfört med thread som jag tyckte var lite bökigare.


            //Användning av mina repository metoder.
            //GetAllPlayersUsingRepository();
            //AddPlayerUsingRepository();
        }


        public static void AddPlayerUsingRepository()
        {
            var playerRepo = new PlayerRepository();
            var player = new Player { FirstName = "Emil", LastName = "Christensen", NickName = "HeatoN", CountryId = 1, BirthDate = new DateTime(1984,5,15), Status = "Retierd", Role = "Rifler" };
            playerRepo.Add(player);
            playerRepo.Save();
        }

        public static void GetAllPlayersUsingRepository()
        {
            var playerRepo = new PlayerRepository();
            var players = playerRepo.GetAll();
            foreach(var player in players)
            {
                Console.WriteLine(player.NickName);
            }
        }

        public static async Task<List<Tournament>> SelectTournamentAndMapsWithAsync()
        {
            var context = new GamepediaContext();
            var result = await context.Tournaments
                .Include(x => x.Maps)
                .ThenInclude(xa => xa.Map)
                .ToListAsync();

            return result;
        }

        public static async Task<List<Team>> SelectTeamAndPlayersWithAsync()
        {
            var context = new GamepediaContext();
            var result = await context.Teams
                .Include(m => m.Players)
                .ThenInclude(ma => ma.Player)
                .ToListAsync();

            return result;
        }
    }
}
