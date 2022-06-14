using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly MattContext mattContext;

        public UserRepository(MattContext mattContext)
        {
            this.mattContext = mattContext;
        }

        public async Task<User> DeleteUser(Guid Id)
        {
            var userToBeDeleted = await this.mattContext.Users.FindAsync(Id);

            if (userToBeDeleted != null)
            {
                this.mattContext.Users.Remove(userToBeDeleted);
                await this.mattContext.SaveChangesAsync();
            }

            return userToBeDeleted;
        }

        public async Task<User> GetUserById(Guid Id)
        {
            var user = await this.mattContext.Users.FindAsync(Id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var userList = await this.mattContext.Users.ToListAsync();
            return userList;
        }

        public async Task<User> SaveUser(User user)
        {
            this.mattContext.Users.Add(user);
            await this.mattContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(Guid Id, User userData)
        {
            var user = await this.mattContext.Users.FindAsync(Id);

            if (user == null) return null;

            user.FirstName = userData.FirstName;
            user.LastName = userData.LastName;
            user.Email = userData.Email;
            user.Phone = userData.Phone;
            user.Message = userData.Message;
            user.Address = userData.Address;

            this.mattContext.Users.Update(user);
            await this.mattContext.SaveChangesAsync();
            return user;
        }
    }
}
