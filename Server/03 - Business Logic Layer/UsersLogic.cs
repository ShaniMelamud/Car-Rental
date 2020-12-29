using System.Collections.Generic;
using System.Linq;

namespace CarRental
{
    public class UsersLogic : BaseLogic
    {
        
        public UsersLogic(CarRentalContext db) : base(db) { }
        public bool IsUserNameExists(string username)
        {
            return DB.Users.Any(u => u.UserName == username);
        }
        public UserModel GetUserByCredentials(CredentialsModel credentials)
        {
            return new UserModel(DB.Users.SingleOrDefault(u => u.UserName == credentials.Username && u.Password == credentials.Password));
        }
        
        public List<UserModel> GetAllUsers()
        {
            return DB.Users.Select(u => new UserModel(u)).ToList();
        }
        public UserModel GetOneUser(int id)
        {
            return DB.Users.Where(u => u.UserId == id).Select(u => new UserModel(u))
                .SingleOrDefault();
        }
        public UserModel AddUser(UserModel userModel)
        {
            User userToAdd = userModel.ConvertToUser();
            DB.Users.Add(userToAdd);
            DB.SaveChanges();
            userModel.ID = userToAdd.UserId;
            return userModel;
        }
        public UserModel UpdateFullUser(UserModel userModel)
        {
            User user = DB.Users.SingleOrDefault(u => u.UserId == userModel.ID);
            if (user == null)
                return null;

            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.IdCard = userModel.IdCard;
            user.LicenseNumber = userModel.LicenseNumber;
            user.LicenseType = userModel.LicenseType;
            user.BirthDate = userModel.BirthDate;
            user.Gender = userModel.Gender;
            user.Email = userModel.Email;
            user.Phone = userModel.Phone;
            user.Role = userModel.Role;
            DB.SaveChanges();
            return userModel;
        }
        public UserModel UpdatePartialUser(UserModel userModel)
        {
            User user = DB.Users.SingleOrDefault(u => u.UserId == userModel.ID);
            if (user == null)
                return null;

            if (userModel.FirstName != null)
                user.FirstName = userModel.FirstName;
            if (userModel.LastName != null)
                user.LastName = userModel.FirstName;
            if (userModel.IdCard != null)
                user.IdCard = userModel.IdCard;
            if (userModel.LicenseNumber != null)
                user.LicenseNumber = userModel.LicenseNumber;
            if (userModel.LicenseType != null)
                user.LicenseType = userModel.LicenseType;
            if (userModel.BirthDate != null)
                user.BirthDate = userModel.BirthDate;
            if (userModel.Gender != null)
                user.Gender = userModel.Gender;
            if (userModel.Email != null)
                user.Email = userModel.Email;
            if (userModel.Phone != null)
                user.Phone = userModel.Phone;
            if (userModel.Role != null)
                user.Role = userModel.Role;
            DB.SaveChanges();
            return userModel;
        }
        public void DeleteUser(int id)
        {
            User userToDelete = DB.Users.SingleOrDefault(u => u.UserId == id);
            if (userToDelete == null)
                return;
            DB.Users.Remove(userToDelete);
            DB.SaveChanges();
        }
    }
}
