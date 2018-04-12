using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamepediaApp.Domain
{
    public class Tournament
    {
        public Tournament()
        {
            Maps = new List<TournamentMap>();
        }

        public int Id { get; set; }
        public string Tier { get; set; }
        public string GameName { get; set; }
        public string TournamentName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PriceMoney { get; set; }
        public Country TheCountry { get; set; }
        public int CountryId { get; set; }
        public Team TheTeam { get; set; }
        public int TeamId { get; set; }
        public List<TournamentMap> Maps { get; set; }
    }
}
