using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowTails.Models.Dog
{
    public class DogListItem
    {
        public int DogId { get; set; }

        public string DogName { get; set; }
        public bool Sex { get; set; }
        public string Age { get; set; }
        public string LocationName { get; set; }
    }
}
