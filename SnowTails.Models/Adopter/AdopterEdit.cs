using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowTails.Models.Adopter
{
    public class AdopterEdit
    {
        public int AdopterId { get; set; }
        public string AdopterName { get; set; }
        public string AdopterAddress { get; set; }
        public string AdopterPhone { get; set; }
        public bool OtherPets { get; set; }
        public bool FencedYard { get; set; }
    }
}
