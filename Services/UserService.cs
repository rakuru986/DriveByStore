using Models.Data;
using Models.Data.Users;
using ViewModels;
using BC = BCrypt.Net.BCrypt;

namespace Services
{ 
    public class UserService : IUserService
    {
        public bool verifyUser(LoginUserViewModel user, UserData foundUser)
        {

            return BC.Verify(user.password, foundUser.PasswordHash);
        }

        public string generatePasswordHash(string password)
        {
            return BC.HashPassword(password);
        }
    }
}
