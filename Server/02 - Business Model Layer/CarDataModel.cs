using System;

namespace CarRental
{
    public class CarDataModel
    {
        public int ID { get; set; }
        public int CarTypeId { get; set; }
        public int? Kilometer { get; set; }
        public DateTime? CreateAt { get; set; }
        public string Gear { get; set; }
        public string Notes { get; set; }
        public string Image { get; set; }
        public int? BranchId { get; set; }
        public virtual CarTypeModel CarType { get; set; }

        public CarDataModel() { }
        public CarDataModel(CarData carData)
        {
            ID = carData.CarDataId;
            CarTypeId = carData.CarTypeId;
            Kilometer = carData.Kilometer;
            CreateAt = carData.CreateAt;
            Gear = carData.Gear;
            Notes = carData.Notes;
            Image = carData.Image;
            BranchId = carData.BranchId;
        }
        public CarData ConvertToCarData()
        {
            CarData carData = new CarData
            {
                CarDataId = ID,
                CarTypeId = CarTypeId,
                Kilometer = Kilometer,
                CreateAt = CreateAt,
                Gear = Gear,
                Notes = Notes,
                Image = Image,
                BranchId = BranchId
            };
            return carData;
        }
    }
}
