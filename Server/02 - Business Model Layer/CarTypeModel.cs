using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    public class CarTypeModel
    {
        public int CarTypeId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal PricePerDayLate { get; set; }

        public CarTypeModel() { }
        public CarTypeModel(CarType carType)
        {
            CarTypeId = carType.CarTypeId;
            Manufacturer = carType.Manufacturer;
            Model = carType.Model;
            PricePerDay = carType.PricePerDay;
            PricePerDayLate = carType.PricePerDayLate;
        }
        public CarType ConvertToCarType()
        {
            CarType carType = new CarType
            {
                CarTypeId = CarTypeId,
                Manufacturer = Manufacturer,
                Model = Model,
                PricePerDay = PricePerDay,
                PricePerDayLate = PricePerDayLate

            };
            return carType;
        }
    }
}
