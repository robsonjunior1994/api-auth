using api_auth.Models;

namespace api_auth.Services.Interface
{
    public interface IUserService
    {
        void Create(User user);
    }
}
