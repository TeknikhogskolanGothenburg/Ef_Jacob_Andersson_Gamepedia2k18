using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamepediaApp.Domain
{
    public class TournamentMap
    {
        public int MapId { get; set; }
        public int TournamentId { get; set; }

        public Map Map { get; set; }
        public Tournament Tournament { get; set; }
    }
}
