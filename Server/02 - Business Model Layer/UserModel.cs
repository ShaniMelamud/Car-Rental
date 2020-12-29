using System;

namespace CarRental
{
    public class UserModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdCard { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseType { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; } = "user";
        public string UserName { get; set; }
        public string Password { get; set; }
        public string JwtToken{ get; set; }
        public string Image { get; set; }
        public DateTime? RegisterDate { get; set; }
        public UserModel(){}
        public UserModel(User user)
        {
            ID = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            IdCard = user.IdCard;
            LicenseNumber = user.LicenseNumber;
            LicenseType = user.LicenseType;
            BirthDate = user.BirthDate;
            Gender = user.Gender;
            Email = user.Email;
            Phone = user.Phone;
            Role = user.Role;
            UserName = user.UserName;
            Password = user.Password;
            Image = user.Image;
            RegisterDate = user.RegisterDate;
        }
        public User ConvertToUser()
        {
            User user = new User
            {
                UserId = ID,
                FirstName = FirstName,
                LastName = LastName,
                IdCard = IdCard,
                LicenseNumber = LicenseNumber,
                LicenseType = LicenseType,
                BirthDate = BirthDate,
                Gender = Gender,
                Email = Email,
                Phone = Phone,
                Role = Role,
                UserName = UserName,
                Password = Password,
                Image = Image,
                RegisterDate = RegisterDate
            };
            return user;
        }
    }
}
