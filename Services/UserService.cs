using Services.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace Services
{ 
    public class UserService : IUserService
    {
        public bool verifyUser(string password, string foundUserHash)
        {
            return BC.Verify(password, foundUserHash);
        }

        public string generatePasswordHash(string password)
        {
            return BC.HashPassword(password);
        }
    }
}
