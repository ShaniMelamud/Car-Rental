using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental
{
    public class CarsTypeLogic : BaseLogic
    {
        public CarsTypeLogic(CarRentalContext db) : base(db) { }

        public List<CarTypeModel> GetAllCarsTypes()
        {
            return DB.CarTypes.Select(c => new CarTypeModel(c)).ToList();
        }
        public CarTypeModel GetOneCarType(int id)
        {
            return DB.CarTypes.Where(c => c.CarTypeId == id).Select(c => new CarTypeModel(c)).SingleOrDefault();
        }
        public CarTypeModel AddCarType(CarTypeModel carTypeToAddModel)
        {
            CarType carTypeToAdd = carTypeToAddModel.ConvertToCarType();
            DB.CarTypes.Add(carTypeToAdd);
            DB.SaveChanges();
            carTypeToAddModel.CarTypeId = carTypeToAdd.CarTypeId;
            return carTypeToAddModel;
        }
        public CarTypeModel UpdateFullCarType(CarTypeModel carTypeModel)
        {
            CarType carType = DB.CarTypes.SingleOrDefault(c => c.CarTypeId == carTypeModel.CarTypeId);
            if (carType == null)
                return null;

            carType.Manufacturer = carTypeModel.Manufacturer;
            carType.Model = carTypeModel.Model;
            carType.PricePerDay = carTypeModel.PricePerDay;
            carType.PricePerDayLate = carTypeModel.PricePerDayLate;
            DB.SaveChanges();
            return carTypeModel;
        }
        public CarTypeModel UpdatePartialCarType(CarTypeModel carTypeModel)
        {
            CarType carType = DB.CarTypes.SingleOrDefault(c => c.CarTypeId == carTypeModel.CarTypeId);
            if (carType == null)
                return null;
            if (carTypeModel.Manufacturer != null)
                carType.Manufacturer = carTypeModel.Manufacturer;
            if (carTypeModel.Model != null)
                carType.Model = carTypeModel.Model;
            if (carTypeModel.PricePerDay != null)
                carType.PricePerDay = carTypeModel.PricePerDay;
            if (carTypeModel.PricePerDayLate != null)
                carType.PricePerDayLate = carTypeModel.PricePerDayLate;
            DB.SaveChanges();
            return carTypeModel;
        }
        public void DeleteCarType(int id)
        {
            CarType carTypeToDelete = DB.CarTypes.SingleOrDefault(c => c.CarTypeId == id);
            if (carTypeToDelete == null)
                return;
            DB.CarTypes.Remove(carTypeToDelete);
            DB.SaveChanges();
        }
    }
}
