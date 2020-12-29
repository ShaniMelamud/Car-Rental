using System.Collections.Generic;
using System.Linq;

namespace CarRental
{
    public class CarDataLogic : BaseLogic
    {
        public CarDataLogic(CarRentalContext db) : base(db) { }
        public List<CarDataModel> GetAllCarsData()
        {
            return DB.CarDatas.Select(c => new CarDataModel(c)).ToList();
        }
        public CarDataModel GetOneCarData(int id)
        {
            return DB.CarDatas.Where(c => c.CarDataId == id).Select(c => new CarDataModel(c)).SingleOrDefault();
        }
        public CarDataModel AddCarData(CarDataModel carDataToAddModel)
        {
            CarData carDataToAdd = carDataToAddModel.ConvertToCarData();
            DB.CarDatas.Add(carDataToAdd);
            DB.SaveChanges();
            carDataToAddModel.ID = carDataToAdd.CarDataId;
            return carDataToAddModel;
        }
        public CarDataModel UpdateFullCarData(CarDataModel carDataModel)
        {
            CarData carData = DB.CarDatas.SingleOrDefault(c => c.CarDataId == carDataModel.ID);
            if (carData == null)
                return null;

            carData.CarTypeId = carDataModel.CarTypeId;
            carData.Kilometer = carDataModel.Kilometer;
            carData.CreateAt = carDataModel.CreateAt;
            carData.Gear = carDataModel.Gear;
            carData.Notes = carDataModel.Notes;
            carData.Image = carDataModel.Image;
            carData.BranchId = carDataModel.BranchId;
            DB.SaveChanges();
            return carDataModel;
        }
        public CarDataModel UpdatePartialCarData(CarDataModel carDataModel)
        {
            CarData carData = DB.CarDatas.SingleOrDefault(c => c.CarDataId == carDataModel.ID);
            if (carData == null)
                return null;
            if (carDataModel.CarTypeId != null)
                carData.CarTypeId = carDataModel.CarTypeId;
            if (carDataModel.Kilometer != null)
                carData.Kilometer = carDataModel.Kilometer;
            if (carDataModel.CreateAt != null)
                carData.CreateAt = carDataModel.CreateAt;
            if (carDataModel.Gear != null)
                carData.Gear = carDataModel.Gear;
            if (carDataModel.Notes != null)
                carData.Notes = carDataModel.Notes;
            if (carDataModel.Image != null)
                carData.Image = carDataModel.Image;
            if (carDataModel.BranchId != null)
                carData.BranchId = carDataModel.BranchId;
            DB.SaveChanges();
            return carDataModel;
        }
        public void DeleteCarData(int id)
        {
            CarData carDataToDelete = DB.CarDatas.SingleOrDefault(c => c.CarDataId == id);
            if (carDataToDelete == null)
                return;
            DB.CarDatas.Remove(carDataToDelete);
            DB.SaveChanges();
        }
    }
}
