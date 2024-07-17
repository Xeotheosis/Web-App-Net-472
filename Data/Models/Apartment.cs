using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public int StaircaseId { get; set; }
        public string Number { get; set; }
        public bool HasGasCentralHeating { get; set; }
        public float SurfaceArea { get; set; }
        public int PeopleCount { get; set; }
        public float? ColdWaterMeterReading { get; set; }
        public float? HotWaterMeterReading { get; set; }
    }
}
