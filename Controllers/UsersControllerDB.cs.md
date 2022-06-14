using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;

namespace api.Controllers
{
    public class UsersController : BaseApiController
    {
        private MattContext mattContext;

        public UsersController(MattContext mattContext)
        {
            this.mattContext = mattContext;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetUser(int Id)
        {
            var user = await this.mattContext.Users.FindAsync(Id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var UserList = await this.mattContext.Users.ToListAsync();
            return Ok(UserList);
        }

        [HttpPost]
        public async Task<ActionResult<User>> SaveUser([FromBody] User user)
        {
            user.Id = 0;
            this.mattContext.Add(user);
            await this.mattContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<User>>
        UpdateUser(int Id, [FromBody] User user)
        {
            var userToBeUpdated = await this.mattContext.Users.FindAsync(Id);

            if (userToBeUpdated == null) return NotFound();

            userToBeUpdated.Age = user.Age;
            userToBeUpdated.FirstName = user.FirstName;
            userToBeUpdated.LastName = user.LastName;

            this.mattContext.Users.Update(userToBeUpdated);
            await this.mattContext.SaveChangesAsync();

            return Ok(userToBeUpdated);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<User>> DeleteUser(int Id)
        {
            var userToBeDeleted = await this.mattContext.Users.FindAsync(Id);

            if (userToBeDeleted == null) return NotFound();

            this.mattContext.Users.Remove(userToBeDeleted);
            await this.mattContext.SaveChangesAsync();

            return Ok(userToBeDeleted);
        }
    }
}
