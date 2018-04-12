using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamepediaApp.Domain
{
    public class Team
    {
        public Team()
        {
            Tournaments = new List<Tournament>();
            Players = new List<TeamPlayer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] TeamLogo { get; set; }
        public DateTime Founded { get; set; }
        public Country TheCountry { get; set; }
        public int CountryId { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public List<TeamPlayer> Players { get; set; }
    }
}
