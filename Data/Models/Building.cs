using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Building
    {
        public int BuildingId { get; set; }
        public int AssociationId { get; set; }
        public string Name { get; set; }
        public ICollection<Staircase> Staircases { get; set; }
        public Building()
        {
            Staircases = new List<Staircase>();
        }
    }
}
