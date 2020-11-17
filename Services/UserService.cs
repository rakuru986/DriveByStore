using Models.Data;
using ViewModels;
using BC = BCrypt.Net.BCrypt;

namespace Services
{ 
    public class UserService
    {
        public bool matchUser(LoginUserViewModel user, UserData foundUser)
        {

            return BC.Verify(user.password, foundUser.PasswordHash);
        }

        public string generatePasswordHash(string password)
        {
            return BC.HashPassword(password);
        }
    }
}
