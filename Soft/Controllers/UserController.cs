using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maps;
using Microsoft.AspNetCore.Mvc;
using Models.Store.Interfaces;
using ViewModels;

namespace Soft.Controllers
{
    public class UserController:Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository ur)
        {
            userRepository = ur;
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody]SaveUserViewModel user)
        {
            if (user == null) return Json(BadRequest());
            var mapper = new UsersMapper();
            var userItem = mapper.mapSaveUser(user);
            await userRepository.Add(userItem);
            return Json(Ok(userItem));
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserViewModel user)
        {
            if (user == null) return Json(BadRequest());

            return Json(Ok());
        }
    }
}
