using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowTails.Models.Adopter
{
    public class AdopterCreate
    {
        [Required]
        [Display(Name = "Full Name")]
        public string AdopterName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string AdopterAddress { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone Number must be numeric")]
        [Display(Name = "Phone Number")]
        public string AdopterPhone { get; set; }
        [Display(Name = "Do you have other pets?")]
        [Required]
        public bool OtherPets { get; set; }
        [Display(Name = "Do you have a fenced in yard?")]
        [Required]
        public bool FencedYard { get; set; }
    }
}
