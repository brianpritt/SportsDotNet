using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsLeague.Models
{
    [Table("Divisions")]
    public class Division
    {
        public Division()
        {
            this.Teams = new HashSet<Team>();
        }
        [Key]
        public int DivisionId { get; set; }
        public string Name { get; set; }
        public string SkillLevel { get; set; }
        public int MaxNumberTeams { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
