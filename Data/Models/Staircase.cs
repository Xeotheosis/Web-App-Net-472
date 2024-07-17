using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Staircase
    {
        public int StaircaseId { get; set; }
        public int BuildingId { get; set; }
        public string Name { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
        public Staircase()
        {
            Apartments = new List<Apartment>();
        }
    }
}
