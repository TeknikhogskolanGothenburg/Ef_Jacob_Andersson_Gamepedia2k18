using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamepediaApp.Domain
{
    public class TeamPlayer
    {
        public int PlayerId { get; set; }
        public int TeamId { get; set; }

        public Player Player { get; set; }
        public Team Team { get; set; }
    }
}
