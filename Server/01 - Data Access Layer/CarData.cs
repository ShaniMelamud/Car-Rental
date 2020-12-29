using System;
using System.Collections.Generic;

#nullable disable

namespace CarRental
{
    public partial class CarData
    {
        public CarData()
        {
            Rentals = new HashSet<Rental>();
        }

        public int CarDataId { get; set; }
        public int CarTypeId { get; set; }
        public int? Kilometer { get; set; }
        public DateTime? CreateAt { get; set; }
        public string Gear { get; set; }
        public string Notes { get; set; }
        public string Image { get; set; }
        public int? BranchId { get; set; }

        public virtual CarType CarType { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
