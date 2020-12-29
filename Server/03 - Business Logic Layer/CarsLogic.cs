using System.Collections.Generic;
using System.Linq;

namespace CarRental
{
    public class CarsLogic : BaseLogic
    {
        public CarsLogic(CarRentalContext db) : base(db) { }

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
    }
}
