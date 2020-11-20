
﻿using System.Threading.Tasks;
using Models.Common.Interfaces;
using Models.Data;


 namespace Models.Store.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<UserData> getUserByEmail(string email);
    }
}
