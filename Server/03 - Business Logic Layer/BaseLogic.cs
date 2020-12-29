using System;

namespace CarRental
{
    public class BaseLogic : IDisposable
    {
        public CarRentalContext DB;
        public BaseLogic(CarRentalContext db)
        {
            DB = db;
        }
        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
