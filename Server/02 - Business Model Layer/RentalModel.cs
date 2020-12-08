using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    public class RentalModel
    {
        public int ID { get; set; }
        public int CarDataId { get; set; }
        public int UserId { get; set; }
        public int BranchStartId { get; set; }
        public int? BranchEndId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? RealEndTime { get; set; }
        public decimal ExpectedPrice { get; set; }
        public decimal? FinalPrice { get; set; }
        public RentalModel(){}
        public RentalModel(Rental rental)
        {
            ID = rental.RentalId;
            CarDataId = rental.CarDataId;
            UserId = rental.UserId;
            BranchStartId = rental.BranchStartId;
            BranchEndId = rental.BranchEndId;
            StartTime = rental.StartTime;
            EndTime = rental.EndTime;
            RealEndTime = rental.RealEndTime;
            ExpectedPrice = rental.ExpectedPrice;
            FinalPrice = rental.FinalPrice;
        }
        public Rental ConvertToRental()
        {
            Rental rental = new Rental
            {
                RentalId = ID,
                CarDataId = CarDataId,
                UserId = UserId,
                BranchStartId = BranchStartId,
                BranchEndId = BranchEndId,
                StartTime = StartTime,
                EndTime = EndTime,
                RealEndTime = RealEndTime,
                ExpectedPrice = ExpectedPrice,
                FinalPrice = FinalPrice
            };
            return rental;
        }
    }
}
