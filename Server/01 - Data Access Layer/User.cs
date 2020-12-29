using System;
using System.Collections.Generic;

#nullable disable

namespace CarRental
{
    public partial class User
    {
        public User()
        {
            Rentals = new HashSet<Rental>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdCard { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseType { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
