using GameShop_Api.Controllers;
using GameShop_Api.Entities.Models;
using GameShop_Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests
{
    public class UserControllerTest
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly UserController _controller;
        public UserControllerTest()
        {
            _mockRepo = new Mock<IUserRepository>();
            _controller = new UserController(null, _mockRepo.Object);
        }
        [Fact]
        public async Task GetAllUsers_ReturnOkResult_WithListOfGames()
        {
            //Arrange
            var Users = new List<User>()
            {
                new User{Id = Guid.NewGuid(), FirstName = "Magzhan", LastName = "Temirbolat", Age = 16},
                new User{Id = Guid.NewGuid(), FirstName = "Oleg", LastName = "Ryadkov", Age = 19 },
            };
            _mockRepo.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(Users);
            //Act
            var httpCode = await _controller.GetAllUsers();
            //Assert
            var okResult = Assert.IsType<OkObjectResult>(httpCode);
            var getResultFromController = Assert.IsType<List<User>>(okResult.Value);
            Assert.Equal(2, getResultFromController.Count());
        }
        [Fact]
        public async Task GetUserById_ReturnFoundResult_WhenUserExists()
        {
            //Arrange
            var Users = new List<User>()
            {
                new User{Id = Guid.NewGuid(), FirstName = "Magzhan", LastName = "Temirbolat", Age = 16},
                new User{Id = Guid.NewGuid(), FirstName = "Oleg", LastName = "Ryadkov", Age = 19 },
            };
            _mockRepo.Setup(x => x.GetUserByIdAsync(Users[0].Id)).ReturnsAsync(Users[0]);
            //Act
            var result = await _controller.GetUserById(Users[0].Id);
            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnUser = Assert.IsType<User>(okResult.Value);
            Assert.Equal(Users[0].Id, returnUser.Id);
        }
        [Fact]
        public async Task GetUserById_ReturnNotFoundResult_WhenUserExists()
        {
            //Arrange
            var nonExistingUserId = Guid.NewGuid();
            _mockRepo.Setup(x => x.GetUserByIdAsync(nonExistingUserId)).ReturnsAsync((User?)null);
            //Act
            var result = await _controller.GetUserById(nonExistingUserId);
            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
