using System;
using System.Collections.Generic;

namespace CarRental
{
    public partial class Rental
    {
        public int RentalId { get; set; }
        public int CarDataId { get; set; }
        public int UserId { get; set; }
        public int BranchStartId { get; set; }
        public int? BranchEndId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? RealEndTime { get; set; }
        public decimal ExpectedPrice { get; set; }
        public decimal? FinalPrice { get; set; }

        public virtual Branch BranchEnd { get; set; }
        public virtual Branch BranchStart { get; set; }
        public virtual CarData CarData { get; set; }
        public virtual CarType CarDataNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
