using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CarRental
{
    public class CarTypeModel
    {
        public int ID { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal? PricePerDay { get; set; }
        public IFormFile Image { get; set; }
        public string ImageFileName { get; set; }


        public CarTypeModel() { }
        public CarTypeModel(CarType carType)
        {
            ID = carType.CarTypeId;
            Manufacturer = carType.Manufacturer;
            Model = carType.Model;
            PricePerDay = carType.PricePerDay;
            ImageFileName = carType.ImageFileName;
        }
        public CarType ConvertToCarType()
        {
            CarType carType = new CarType
            {
                CarTypeId = ID,
                Manufacturer = Manufacturer,
                Model = Model,
                PricePerDay = PricePerDay,
                ImageFileName = ImageFileName

            };
            return carType;
        }
    }
}
