using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowTails.Models.Dog
{
    public class DogEdit
    {
        public int DogId { get; set; }
        [Display(Name = "Name")]
        public string DogName { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public string Fixed { get; set; }
        public string Information { get; set; }
        public string LocationName { get; set; }
        public int LocationId { get; set; }
        public int AdopterId { get; set; }
    }
}
