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
        [Display(Name = "Name")]
        public string DogName { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Fixed { get; set; }
        [Required]
        public string Information { get; set; }
        [Display(Name = "Location")]
        public int LocationId { get; set; }
    }
}
