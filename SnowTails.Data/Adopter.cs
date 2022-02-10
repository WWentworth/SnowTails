using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowTails.Data
{
    public class Adopter
    {
        [Key]
        public int AdopterId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]

        public string AdopterName { get; set; }
        [Required]
        public string  AdopterAddress { get; set; }
        [Required]
        public string AdopterPhone { get; set; }
        [Required]
        public bool OtherPets { get; set; }
        [Required]
        public bool FencedYard { get; set; }
    }
}
