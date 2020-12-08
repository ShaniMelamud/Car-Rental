using System;
using System.Collections.Generic;

namespace CarRental
{
    public partial class Branch
    {
        public Branch()
        {
            RentalBranchEnds = new HashSet<Rental>();
            RentalBranchStarts = new HashSet<Rental>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string ActivityTime { get; set; }

        public virtual ICollection<Rental> RentalBranchEnds { get; set; }
        public virtual ICollection<Rental> RentalBranchStarts { get; set; }
    }
}
