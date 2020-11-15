using System;
using System.Collections.Generic;
using System.Text;
using Models.Data;
using ViewModels;

namespace Services
{ 
    public class UserService
    {
        public bool matchUser(LoginUserViewModel user, UserData foundUser)
        {
            return user.passwordHash == foundUser.PasswordHash;
        }
    }
}
