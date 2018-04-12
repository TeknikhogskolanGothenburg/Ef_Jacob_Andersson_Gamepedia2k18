using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamepediaApp.Domain
{
    public class Player
    {
        public Player()
        {
            Teams = new List<TeamPlayer>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string NickName { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public Country TheCountry { get; set; }
        public int CountryId { get; set; }
        public List<TeamPlayer> Teams { get; set; }
    }
}
