using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            string extension = Path.GetExtension(carTypeToAddModel.Image.FileName);
            carTypeToAddModel.ImageFileName = Guid.NewGuid() + extension;
            using (FileStream fileStream = File.Create("Uploads/" + carTypeToAddModel.ImageFileName))
                carTypeToAddModel.Image.CopyTo(fileStream);

            carTypeToAddModel.Image = null;

            CarType carTypeToAdd = carTypeToAddModel.ConvertToCarType();
            DB.CarTypes.Add(carTypeToAdd);
            DB.SaveChanges();
            carTypeToAddModel.ID = carTypeToAdd.CarTypeId;
            return carTypeToAddModel;
        }
        public CarTypeModel UpdateFullCarType(CarTypeModel carTypeModel)
        {
            CarType carType = DB.CarTypes.SingleOrDefault(c => c.CarTypeId == carTypeModel.ID);
            if (carType == null)
                return null;

            carType.Manufacturer = carTypeModel.Manufacturer;
            carType.Model = carTypeModel.Model;
            carType.PricePerDay = carTypeModel.PricePerDay;
            DB.SaveChanges();
            return carTypeModel;
        }
        public CarTypeModel UpdatePartialCarType(CarTypeModel carTypeModel)
        {
            CarType carType = DB.CarTypes.SingleOrDefault(c => c.CarTypeId == carTypeModel.ID);
            if (carType == null)
                return null;
            if (carTypeModel.Manufacturer != null)
                carType.Manufacturer = carTypeModel.Manufacturer;
            if (carTypeModel.Model != null)
                carType.Model = carTypeModel.Model;
            if (carTypeModel.PricePerDay != null)
                carType.PricePerDay = carTypeModel.PricePerDay;
           
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


        //get activity cars by dates
        public List<CarDataModel> CheckCarsActivity(DateTime start, DateTime end)
        {
            if (start > end)
                return null;
            List<RentalModel> rentals = DB.Rentals.Select(r => new RentalModel(r)).ToList();
            List<int> UnAvailableCarsID = new List<int>();
            foreach (RentalModel r in rentals)
            {
                if (
                    //check if dates are availble                   
                    r.PickUpTime >= start && r.ReturnTime <= end ||
                       r.PickUpTime >= start && r.PickUpTime <= end && r.ReturnTime >= end ||
                       r.PickUpTime <= start && r.ReturnTime >= end ||
                       r.PickUpTime <= start && r.ReturnTime >= start && r.ReturnTime <= end)
                {
                    // - add the car to the unavailble cars

                    UnAvailableCarsID.Add(r.CarDataId);
                }
            }
            List<CarDataModel> carsDataModel = DB.CarDatas.Select(c => new CarDataModel(c)).ToList();
            foreach (int item in UnAvailableCarsID)
            {
                CarDataModel carDataModel = carsDataModel.Where(c => c.ID == item).SingleOrDefault();
                if (carsDataModel != null)
                    //remove unavailble cars froms main array
                    carsDataModel.Remove(carDataModel);
            };
            List<CarDataModel> availableCarsData = carsDataModel;
            List<CarTypeModel> allCarsType = GetAllCarsTypes();
            List<CarTypeModel> availableCarsType = new List<CarTypeModel>();
            foreach (CarDataModel item in availableCarsData)
            {
                //fill the availble cars array and return cars type
                item.CarType = GetOneCarType(item.CarTypeId);
               
            }
            return availableCarsData;
        }
    }
}

