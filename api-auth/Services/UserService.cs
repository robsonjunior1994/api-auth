using api_auth.Models;
using api_auth.Services.Interface;
using MongoDB.Driver;

namespace api_auth.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoClient _mongoClient;
        public UserService(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }
        public void Create(User user)
        {
            throw new NotImplementedException();
        }
    }
}
