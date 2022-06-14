using api.Models;

namespace api.Data
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUserById(Guid Id);

        Task<User> SaveUser(User user);

        Task<User> UpdateUser(Guid Id, User user);

        Task<User> DeleteUser(Guid Id);
    }
}
