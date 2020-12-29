using System;
using System.Collections.Generic;

#nullable disable

namespace CarRental
{
    public partial class CarType
    {
        public CarType()
        {
            CarDatas = new HashSet<CarData>();
        }

        public int CarTypeId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal? PricePerDay { get; set; }
        public string ImageFileName { get; set; }

        public virtual ICollection<CarData> CarDatas { get; set; }
    }
}
