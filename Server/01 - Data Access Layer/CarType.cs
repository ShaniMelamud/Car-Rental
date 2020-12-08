using System;
using System.Collections.Generic;

namespace CarRental
{
    public partial class CarType
    {
        public CarType()
        {
            Rentals = new HashSet<Rental>();
        }

        public int CarTypeId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal PricePerDayLate { get; set; }

        public virtual CarData CarData { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
