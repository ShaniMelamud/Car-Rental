using System;

namespace CarRental
{
    public class CarModel
    {
       public CarDataModel CarData { get; set; }
       public CarTypeModel CarType { get; set; }

        public CarModel()
        {

        }
        public CarModel(CarDataModel carData, CarTypeModel carType)
        {
            this.CarData = carData;
            this.CarType = carType;
        }
    }
}
