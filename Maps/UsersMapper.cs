using Models.Data;
using Models.Store;
using Services;
using ViewModels;

namespace Maps
{
    public class UsersMapper
    {

        public User mapSaveUser(SaveUserViewModel user)
        {
            string passwordHash = new UserService().generatePasswordHash(user.password);
            var userItem = new UserData
            {
                Email = user.email,
                FirstName = user.firstName,
                LastName = user.lastName,
                PhoneNumber = user.phoneNumber,
                PasswordHash = passwordHash,
                
            };
            return  new User(userItem);
        }
    }
}
