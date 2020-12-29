using System;

namespace CarRental
{
    public class RentalModel
    {
        public int ID { get; set; }
        public int CarDataId { get; set; }
        public int? UserId { get; set; }
        public int? BranchStartId { get; set; }
        public int? BranchEndId { get; set; }
        public DateTime? PickUpTime { get; set; }
        public DateTime? ReturnTime { get; set; }
        public DateTime? FinalReturnTime { get; set; }
        public decimal? ExpectedPrice { get; set; }
        public decimal? FinalPrice { get; set; }
       
        public RentalModel(){}
        public RentalModel(Rental rental)
        {
            ID = rental.RentalId;
            CarDataId = rental.CarDataId;
            UserId = rental.UserId;
            BranchStartId = rental.BranchStartId;
            BranchEndId = rental.BranchEndId;
            PickUpTime = rental.PickUpTime;
            ReturnTime = rental.ReturnTime;
            FinalReturnTime = rental.FinalReturnTime;
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
                PickUpTime = PickUpTime,
                ReturnTime = ReturnTime,
                FinalReturnTime = FinalReturnTime,
                ExpectedPrice = ExpectedPrice,
                FinalPrice = FinalPrice
            };
            return rental;
        }
    }
}
