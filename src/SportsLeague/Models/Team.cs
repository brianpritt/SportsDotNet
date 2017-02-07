using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsLeague.Models
{
    [Table("Teams")]
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string Captain { get; set; }
        public int DivisionId { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
