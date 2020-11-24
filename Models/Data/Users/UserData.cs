using Models.Data.Common;

namespace Models.Data.Users
{
    public sealed class UserData :UniqueEntityData
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        
    }
}