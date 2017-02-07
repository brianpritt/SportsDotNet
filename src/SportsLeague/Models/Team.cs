using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsLeague.Models
{
    [Table("Teams")]
    public class Team
    {
        //public Team()
        //{
        //    this.Players = new HashSet<Player>();
        //}
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int Captain { get; set; }
        public int DivisionId { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
