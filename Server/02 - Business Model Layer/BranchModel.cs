using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    public class BranchModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ActivityTime { get; set; }
        public BranchModel(){}
        public BranchModel(Branch branch)
        {
            ID = branch.BranchId;
            Name = branch.BranchName;
            Country = branch.Country;
            City = branch.City;
            Longitude = branch.Longitude;
            Latitude = branch.Latitude;
            Phone = branch.Phone2;
            Email = branch.Email;
            ActivityTime = branch.ActivityTime;
        }
        public Branch ConvertToBranch()
        {
            Branch branch = new Branch
            {
                BranchId = ID,
                BranchName = Name,
                Country = Country,
                City = City,
                Longitude = Longitude,
                Latitude = Latitude,
                Phone2 = Phone,
                Email = Email,
                ActivityTime = ActivityTime
            };
            return branch;
        }
    }

}
