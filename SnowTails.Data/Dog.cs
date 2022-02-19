using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowTails.Data
{
    public class Dog
    {
        [Key]
        public int DogId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string DogName { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]  
        public string Age { get; set; }
        [Required]
        public string Fixed { get; set; }
        [Required]
        public string Information { get; set; }
        [ForeignKey("Adopter")]
        public int ?AdopterId { get; set; }
        public virtual Adopter Adopter { get; set; }
        public string AdopterName { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        [Display(Name = "Location")]
        public string LocationName { get; set; }
        public virtual Location Location { get; set; }
    }
}
