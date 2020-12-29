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
        public BranchModel(){}
        public BranchModel(Branch branch)
        {
            ID = branch.BranchId;
            Name = branch.BranchName;
            Country = branch.Country;
            City = branch.City;
            Longitude = branch.Longitude;
            Latitude = branch.Latitude;
            Phone = branch.Phone;
            Email = branch.Email;
            
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
                Phone = Phone,
                Email = Email
            };
            return branch;
        }
    }

}
