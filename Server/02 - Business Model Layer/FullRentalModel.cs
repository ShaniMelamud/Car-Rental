using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    public class FullRentalModel
    {
        public RentalModel rentalModel { get; set; }
        public UserModel userModel { get; set; }
        public BranchModel branchModelPickUp { get; set; }
        public BranchModel branchModelReturn { get; set; }
        public CarModel carModel { get; set; }
    }
}
