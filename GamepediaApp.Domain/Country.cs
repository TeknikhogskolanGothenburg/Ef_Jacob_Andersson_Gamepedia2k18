using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamepediaApp.Domain
{
    public class Country
    {
        public Country()
        {
            Players = new List<Player>();
            Tournaments = new List<Tournament>();
            Teams = new List<Team>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public byte[] FlagImage { get; set; }
        public List<Player> Players { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public List<Team> Teams { get; set; }
    }
}
