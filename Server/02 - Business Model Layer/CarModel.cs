using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    public class CarModel
    {
        public int CarTypeId { get; set; }
        public int CarDataID { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal PricePerDayLate { get; set; }
        public int Kilometer { get; set; }
        public DateTime CreateAt { get; set; }
        public string Gear { get; set; }
        public string IsOk { get; set; }
        public string Notes { get; set; }
        public string Image { get; set; }
        public int? BranchId { get; set; }
    }
}
