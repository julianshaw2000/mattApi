using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;

namespace api.Controllers
{
    public class UsersController : BaseApiController
    {
        private IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetUser(Guid Id)
        {
            var user = await this.userRepository.GetUserById(Id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var UserList = await this.userRepository.GetUsers();
            return Ok(UserList);
        }

        [HttpPost]
        public async Task<ActionResult<User>> SaveUser([FromBody] User user)
        {
            var SavedUser = await this.userRepository.SaveUser(user);
            return Ok(SavedUser);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<User>>
        UpdateUser(Guid Id, [FromBody] User user)
        {
            if (user == null)
            {
                return NotFound();
            }

            var UpdatedUser = await this.userRepository.UpdateUser(Id, user);
            return Ok(UpdatedUser);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<User>> DeleteUser(Guid Id)
        {
            var user = await this.userRepository.GetUserById(Id);

            if (user == null)
            {
                return NotFound();
            }

            var DeletedUser = await this.userRepository.DeleteUser(Id);
            return Ok(DeletedUser);
        }
    }
}
