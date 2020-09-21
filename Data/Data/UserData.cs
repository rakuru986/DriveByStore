using Microsoft.AspNetCore.Identity;

namespace DriveByStore.Models.Data
{
    public class UserData : IdentityUser 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}