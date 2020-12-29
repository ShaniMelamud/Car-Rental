using System.Collections.Generic;
using System.Linq;

namespace CarRental
{
    public class RentalsLogic : BaseLogic
    {
        public RentalsLogic(CarRentalContext db) : base(db) { }

        public List<CarModel> GetAllCars()
        {
            List<CarTypeModel> carsTypes = DB.CarTypes.Select(c => new CarTypeModel(c)).ToList();
            List<CarDataModel> carsData = DB.CarDatas.Select(c => new CarDataModel(c)).ToList();
            List<CarModel> carsModel = new List<CarModel>();
            for (int i = 0; i < carsData.Count; i++)
            {
                CarModel carModel = new CarModel();
                carModel.CarData = carsData[i];
                carModel.CarType = carsTypes.Where(c => c.ID == carModel.CarData.CarTypeId).SingleOrDefault();
                carsModel.Add(carModel);
            }
            return carsModel;
        }
        public List<FullRentalModel> GetAllFullRentals()
        {
            List<RentalModel> rentals = GetAllRentals();
            List<CarModel> cars = GetAllCars();
            List<UserModel> users = DB.Users.Select(u => new UserModel(u)).ToList();
            List<BranchModel> branches = DB.Branches.Select(b => new BranchModel(b)).ToList();

            List<FullRentalModel> fullRentals = new List<FullRentalModel>();

            for (int i = 0; i < rentals.Count; i++)
            {
                FullRentalModel fullRental = new FullRentalModel();
                fullRental.rentalModel = rentals[i];
                fullRental.carModel = cars.Where(c => c.CarData.ID == fullRental.rentalModel.CarDataId).SingleOrDefault();
                fullRental.branchModelPickUp = branches.Where(b => b.ID == fullRental.rentalModel.BranchStartId).SingleOrDefault();
                fullRental.branchModelReturn = branches.Where(b => b.ID == fullRental.rentalModel.BranchEndId).SingleOrDefault();
                fullRental.userModel = users.Where(u => u.ID == fullRental.rentalModel.UserId).SingleOrDefault();
                
                fullRentals.Add(fullRental);
            }
            return fullRentals;
        }
        public List<RentalModel> GetRentalsForUser(int userId)
        {
            return DB.Rentals.Where(r => r.UserId == userId).Select(r => new RentalModel(r)).ToList();
        }
        public List<RentalModel> GetAllRentals()
        {
            return DB.Rentals.Select(r => new RentalModel(r)).ToList();
        }
        public RentalModel GetOneRental(int id)
        {
            return DB.Rentals.Where(r => r.RentalId == id).Select(r => new RentalModel(r))
                .SingleOrDefault();
        }
        public RentalModel AddRental(RentalModel rentalModel)
        {
            Rental rentalToAdd = rentalModel.ConvertToRental();
            DB.Rentals.Add(rentalToAdd);
            DB.SaveChanges();
            rentalModel.ID = rentalToAdd.RentalId;
            return rentalModel;
        }
        public RentalModel UpdateFullRental(RentalModel rentalModel)
        {
            Rental rental = DB.Rentals.SingleOrDefault(r => r.RentalId == rentalModel.ID);
            if (rental == null)
                return null;

            rental.CarDataId = rentalModel.CarDataId;
            rental.UserId = rentalModel.UserId;
            rental.BranchStartId = rentalModel.BranchStartId;
            rental.BranchEndId = rentalModel.BranchEndId;
            rental.PickUpTime = rentalModel.PickUpTime;
            rental.ReturnTime = rentalModel.ReturnTime;
            rental.FinalReturnTime = rentalModel.FinalReturnTime;
            rental.ExpectedPrice = rentalModel.ExpectedPrice;
            rental.FinalPrice = rentalModel.FinalPrice;
            DB.SaveChanges();
            return rentalModel;
        }
        public RentalModel UpdatePartialRental(RentalModel rentalModel)
        {
            Rental rental = DB.Rentals.SingleOrDefault(r => r.RentalId == rentalModel.ID);
            if (rental == null)
                return null;

            if (rentalModel.CarDataId != null)
                rental.CarDataId = rentalModel.CarDataId;
            if (rentalModel.UserId != null)
                rental.UserId = rentalModel.UserId;
            if (rentalModel.BranchStartId != null)
                rental.BranchStartId = rentalModel.BranchStartId;
            if (rentalModel.BranchEndId != null)
                rental.BranchEndId = rentalModel.BranchEndId;
            if (rentalModel.PickUpTime != null)
                rental.PickUpTime = rentalModel.PickUpTime;
            if (rentalModel.ReturnTime != null)
                rental.ReturnTime = rentalModel.ReturnTime;
            if (rentalModel.FinalReturnTime != null)
                rental.FinalReturnTime = rentalModel.FinalReturnTime;
            if (rentalModel.ExpectedPrice != null)
                rental.ExpectedPrice = rentalModel.ExpectedPrice;
            if (rentalModel.FinalPrice != null)
                rental.FinalPrice = rentalModel.FinalPrice;
            DB.SaveChanges();
            return rentalModel;
        }
        public void DeleteRental(int id)
        {
            Rental rentalToDelete = DB.Rentals.SingleOrDefault(r => r.RentalId == id);
            if (rentalToDelete == null)
                return;
            DB.Rentals.Remove(rentalToDelete);
            DB.SaveChanges();
        }
    }
}
