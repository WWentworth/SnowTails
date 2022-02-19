using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowTails.Models.Dog
{
    public class DogDetail
    {
        public int DogId { get; set; }

        public string DogName { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public string Fixed { get; set; }
        [Display(Name = "Location")]
        public string LocationName { get; set; }
        [Display(Name = "Pending Adopter")]
        public string AdopterName { get; set; }
        public string Information { get; set; }
        public int AdopterId { get; set; }
        public int LocationId { get; set; }
    }
}
