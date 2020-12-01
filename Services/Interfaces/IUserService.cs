using Models.Data;
using ViewModels;

namespace Services.Interfaces
{
    public interface IUserService
    {
        bool verifyUser(LoginUserViewModel user, UserData foundUser);
        string generatePasswordHash(string password);
    }
}
