using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental
{
    public class CarsLogic : BaseLogic
    {
        public CarsLogic(CarRentalContext db) : base(db) { }

        public List<CarType> GetAllCarsTypes()
        {
            return DB.CarTypes.Select(c => c).ToList();
        }
        public List<CarData> GetAllCarsdata()
        {
            return DB.CarDatas.Select(c => c).ToList();
        }
        public List<CarModel> GetAllCars()
        {
            var cars = DB.CarTypes
                .Join(
                DB.CarDatas,
                cartype => cartype.CarTypeId,
                cardata => cardata.CarDataId,
                (cartype, cardata) => new CarModel()
                {
                    CarTypeId = cartype.CarTypeId,
                    CarDataID = cardata.CarDataId,
                    Manufacturer = cartype.Manufacturer,
                    Model = cartype.Model,
                    PricePerDay = cartype.PricePerDay,
                    PricePerDayLate = cartype.PricePerDayLate,
                    Kilometer = cardata.Kilometer,
                    CreateAt = cardata.CreateAt,
                    Gear = cardata.Gear,
                    IsOk = cardata.IsOk,
                    Notes = cardata.Notes,
                    Image = cardata.Image,
                    BranchId = cardata.BranchId

                }
                ).SingleOrDefault();

            return cars;
            //var cars = (from T in DB.CarTypes
            //            join D in DB.CarDatas on T.CarTypeId equals D.CarTypeId
            //            where D.CarTypeId == new CarTypeModel().CarTypeId
            //            select  new ).SingleOrDefault();
            //return List<C> ;
        }
    }
}
