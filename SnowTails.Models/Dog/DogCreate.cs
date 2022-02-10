using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowTails.Models.Dog
{
    public class DogCreate
    {
        [Required]
        public string DogName { get; set; }
        [Required]
        public bool Sex { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public bool Fixed { get; set; }
        [Required]
        public string Information { get; set; }
        public int LocationId { get; set; }
    }
}
