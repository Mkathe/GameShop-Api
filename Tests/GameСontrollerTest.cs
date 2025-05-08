using GameShop_Api.Controllers;
using GameShop_Api.DTOs.GameDto;
using GameShop_Api.Entities.Models;
using GameShop_Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests
{
    public class GameСontrollerTest
    {
        private readonly Mock<IGameRepository> _mockRepo;
        private readonly GameController _controller;

        public GameСontrollerTest()
        {
            _mockRepo = new Mock<IGameRepository>();
            _controller = new GameController(null!, _mockRepo.Object);
        }

        [Fact]
        public async Task GetAllGames_ReturnsOkResult_WithListOfGames()
        {
            // Arrange
            var testGames = new List<Game>
            {
                new Game {
                    Id = Guid.NewGuid(),
                    GameName = "Cyberpunk 2077",
                    GameGenre = "RPG",
                    GamePublisher = "CD Projekt Red",
                    GameReleaseYear = 2020,
                    GameText = "English, Russian",
                    GameSound = "Dolby Atmos",
                    SystemRequirementNavigation = null
                },
                new Game {
                    Id = Guid.NewGuid(),
                    GameName = "The Witcher 3",
                    GameGenre = "RPG",
                    GamePublisher = "CD Projekt Red",
                    GameReleaseYear = 2015,
                    GameText = "English, Polish",
                    GameSound = "Stereo",
                    SystemRequirementNavigation = null
                }
            };

            _mockRepo.Setup(repo => repo.GetAllGamesAsync())
                    .ReturnsAsync(testGames);
            // Act
            var result = await _controller.GetAllGames();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Game>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
            Assert.Equal("Cyberpunk 2077", returnValue[0].GameName);
            Assert.Equal("CD Projekt Red", returnValue[1].GamePublisher);
        }

        [Fact]
        public async Task GetGameById_ReturnsOkResult_WhenGameExists()
        {
            // Arrange
            var testId = Guid.NewGuid();
            var testGame = new Game
            {
                Id = testId,
                GameName = "Red Dead Redemption 2",
                GameGenre = "Adventure",
                GamePublisher = "Rockstar Games",
                GameReleaseYear = 2018,
                GameText = "English, Spanish",
                GameSound = "Surround 5.1",
                SystemRequirementNavigation = null
            };

            _mockRepo.Setup(repo => repo.GetGameByIdAsync(testId))
                    .ReturnsAsync(testGame);

            // Act
            var result = await _controller.GetGameById(testId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnGame = Assert.IsType<Game>(okResult.Value);
            Assert.Equal(testId, returnGame.Id);
            Assert.Equal("Red Dead Redemption 2", returnGame.GameName);
            Assert.Equal(2018, returnGame.GameReleaseYear);
        }

        [Fact]
        public async Task AddGame_ReturnsCreatedResponse_WithGame_WhenValid()
        {
            // Arrange
            var newGameDto = new CreateGameFromDto
            {
                GameName = "Elden Ring",
                GameGenre = "Action RPG",
                GamePublisher = "FromSoftware",
                GameReleaseYear = 2022,
                GameText = "English, Japanese",
                GameSound = "3D Audio"
            };

            var expectedGame = new Game
            {
                Id = Guid.NewGuid(),
                GameName = newGameDto.GameName,
                GameGenre = newGameDto.GameGenre,
                GamePublisher = newGameDto.GamePublisher,
                GameReleaseYear = newGameDto.GameReleaseYear,
                GameText = newGameDto.GameText,
                GameSound = newGameDto.GameSound,
                SystemRequirementNavigation = null
            };

            _mockRepo.Setup(repo => repo.CreateGameAsync(It.IsAny<Game>()))
                    .ReturnsAsync(expectedGame);

            // Act
            var result = await _controller.AddGame(newGameDto);

            // Assert
            var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result);

            // Изменено с Game на CreateGameFromDto
            var returnDto = Assert.IsType<CreateGameFromDto>(createdAtRouteResult.Value);

            Assert.Equal(nameof(_controller.GetGameById), createdAtRouteResult.RouteName);
            Assert.Equal("Elden Ring", returnDto.GameName);
            Assert.Equal("FromSoftware", returnDto.GamePublisher);
            Assert.Equal("3D Audio", returnDto.GameSound);
        }

        [Fact]
        public async Task UpdateGame_ReturnsNoContent_WhenSuccessful()
        {
            // Arrange
            var gameId = Guid.NewGuid();
            var updateDto = new UpdateGameFromDto
            {
                GameName = "Starfield Updated",
                GameGenre = "RPG Updated",
                GamePublisher = "Bethesda Updated",
                GameReleaseYear = 2023,
                GameText = "English, German Updated",
                GameSound = "Dolby Atmos Updated"
            };

            var updatedGame = new Game
            {
                Id = gameId,
                GameName = updateDto.GameName,
                GameGenre = updateDto.GameGenre,
                GamePublisher = updateDto.GamePublisher,
                GameReleaseYear = updateDto.GameReleaseYear,
                GameText = updateDto.GameText,
                GameSound = updateDto.GameSound
            };

            _mockRepo.Setup(repo => repo.UpdateGameAsync(gameId, updateDto))
                    .ReturnsAsync(updatedGame);

            // Act
            var result = await _controller.UpdateGame(gameId, updateDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteGame_ReturnsNoContent_WhenSuccessful()
        {
            // Arrange
            var gameId = Guid.NewGuid();
            var gameToDelete = new Game
            {
                Id = gameId,
                GameName = "Horizon Forbidden West",
                GameGenre = "Action RPG",
                GamePublisher = "Sony",
                GameReleaseYear = 2022,
                GameText = "English, Dutch",
                GameSound = "Tempest 3D"
            };

            _mockRepo.Setup(repo => repo.DeleteGameAsync(gameId))
                    .ReturnsAsync(gameToDelete);

            // Act
            var result = await _controller.DeleteGame(gameId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
