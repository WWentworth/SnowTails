using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowTails.Data
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]

        public string LocationName { get; set; }
        [Required]
        public string LocationCity { get; set; }
        [Required]
        public string LocationAddress { get; set; }
        [Required]
        public string LocationPhone { get; set; }
    }
}
