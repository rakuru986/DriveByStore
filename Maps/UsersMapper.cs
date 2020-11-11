using Models.Data;
using Models.Store;
using ViewModels;

namespace Maps
{
    public class UsersMapper
    {
        public User mapSaveUser(SaveUserViewModel user)
        {
            UserData userItem = new UserData
            {
                Email = user.email,
                FirstName = user.firstName,
                LastName = user.lastName,
                PhoneNumber = user.phoneNumber,
                PasswordHash = user.passwordHash,
                
            };
            return  new User(userItem);
        }
    }
}
