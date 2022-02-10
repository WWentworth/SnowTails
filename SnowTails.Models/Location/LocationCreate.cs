using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowTails.Models.Location
{
   public class LocationCreate
    {
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

