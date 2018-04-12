using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamepediaApp.Domain
{
    public class Map
    {
        public Map()
        {
            Tournaments = new List<TournamentMap>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Launch { get; set; }
        public List<TournamentMap> Tournaments { get; set; }
    }
}
