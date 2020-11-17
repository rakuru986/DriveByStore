using System.Threading.Tasks;
using Maps;
using Microsoft.AspNetCore.Mvc;
using Models.Store.Interfaces;
using Services;
using ViewModels;

namespace Soft.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private UsersMapper mapper;
        private UserService service;

        public UserController(IUserRepository ur)
        {
            userRepository = ur;
            mapper = new UsersMapper();
            service = new UserService();
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody]SaveUserViewModel user)
        {
            if (user == null) return Json(BadRequest());
            var userItem = mapper.mapSaveUser(user);
            var findUser = await userRepository.getUserByEmail(user.email);
            if (findUser != null) return Json(BadRequest("User with given email already exists"));
            await userRepository.Add(userItem);
            return Json(Ok(userItem));
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserViewModel user)
        {
            if (user == null) return Json(BadRequest());
            var foundUser = await userRepository.getUserByEmail(user.email);
            if (foundUser != null)
            {
                return service.matchUser(user, foundUser) ? Json(Ok(foundUser)) : Json(BadRequest("Wrong username or password"));
            }
            return Json(BadRequest("User with given email not found"));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser([FromQuery(Name = "id")] string id)
        {
            await userRepository.Delete(id);
            var foundUser = await userRepository.Get(id);
            return foundUser.Data == null ? Json(Ok()) : Json(BadRequest());
        }
    }
}
