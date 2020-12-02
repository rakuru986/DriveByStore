using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Services.Interfaces;
using ViewModels;

namespace Soft.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IMapperService mapper;
        private IUserService service;

        public UserController(IUserRepository ur, IMapperService ms, IUserService us)
        {
            userRepository = ur;
            mapper = ms;
            service = us;
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody]SaveUserViewModel user)
        {
            if (user == null) return Json(BadRequest());
            var userItem = mapper.mapSaveUser(user, service);
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
                return service.verifyUser(user, foundUser) ? Json(Ok(foundUser)) : Json(Unauthorized("Wrong username or password"));
            }
            return Json(Unauthorized("Wrong username or password"));
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
