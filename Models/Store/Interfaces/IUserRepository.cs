<<<<<<< HEAD
﻿using System.Threading.Tasks;
using Models.Common.Interfaces;
using Models.Data;
=======
﻿using Models.Common.Interfaces;
>>>>>>> 61e5969 (Base repository jätk ja util klasside lisamine)

namespace Models.Store.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<UserData> getUserByEmail(string email);
    }
}
