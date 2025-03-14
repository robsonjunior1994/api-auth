using api_auth.Models;
using api_auth.Services;
using Autofac.Extras.Moq;
using Moq;

namespace test_auth.Services
{
    public class UserServiceTests
    {
        private readonly UserService _sut;
        private readonly AutoMock _mock;

        public UserServiceTests()
        {
            _mock = AutoMock.GetLoose();
            _sut = _mock.Create<UserService>();
        }

        [Fact]
        public void GivenAnExistingEmail_WhenCreatingOneUserThenItShouldFail()
        {
            //Arrange
            var user = new User
            {
                Username = "existente",
                Email = "existe@mail.com",
            };

            //Act
            _sut.Create(user);

            //Assert
        }
    }
}