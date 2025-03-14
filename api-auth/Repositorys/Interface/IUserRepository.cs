using api_auth.Models;

namespace api_auth.Repositorys.Interface
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
    }
}
