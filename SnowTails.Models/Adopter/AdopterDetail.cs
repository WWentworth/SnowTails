using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowTails.Models.Adopter
{
    public class AdopterDetail
    {
        public int AdopterId { get; set; }
        public string AdopterName { get; set; }
        public string AdopterAddress { get; set; }
        public string AdopterPhone { get; set; }
        [Display(Name = "Do you have other pets?")]
        public bool OtherPets { get; set; }
        [Display(Name = "Do you have a fenced yard?")]
        public bool FencedYard { get; set; }
    }
}
