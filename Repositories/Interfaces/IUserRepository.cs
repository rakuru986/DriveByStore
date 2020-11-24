using System.Threading.Tasks;
using Models.Common.Interfaces;
using Models.Data;
using Models.Store;

namespace Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<UserData> getUserByEmail(string email);
    }
}
