using GameShop_Api.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShop_Api.Data
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {


            // Генерация пользователей
            var users = new User[]
            {
                new User {Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Age = 25 },
                new User {Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", Age = 30 },
                new User {Id = Guid.NewGuid(), FirstName = "Alex", LastName = "Johnson", Age = 22 },
                new User {Id = Guid.NewGuid(), FirstName = "Emily", LastName = "Williams", Age = 28 },
                new User {Id = Guid.NewGuid(), FirstName = "Michael", LastName = "Brown", Age = 35 },
                new User {Id = Guid.NewGuid(), FirstName = "Sarah", LastName = "Jones", Age = 27 },
                new User {Id = Guid.NewGuid(), FirstName = "David", LastName = "Garcia", Age = 31 },
                new User {Id = Guid.NewGuid(), FirstName = "Jessica", LastName = "Miller", Age = 24 },
                new User {Id = Guid.NewGuid(), FirstName = "Daniel", LastName = "Davis", Age = 29 },
                new User {Id = Guid.NewGuid(), FirstName = "Olivia", LastName = "Rodriguez", Age = 26 }
            };
            modelBuilder.Entity<User>().HasData(users);
            // Генерация игр
            var games = new Game[]
            {
                new Game {Id = Guid.NewGuid(), GameName = "Cyberpunk 2077", GameGenre = "RPG", GameReleaseYear = 2020, GamePublisher = "CD Projekt Red", GameText = "English, Russian", GameSound = "Dolby Atmos" },
                new Game {Id = Guid.NewGuid(), GameName = "The Witcher 3", GameGenre = "RPG", GameReleaseYear = 2015, GamePublisher = "CD Projekt Red", GameText = "English, Polish", GameSound = "Stereo" },
                new Game {Id = Guid.NewGuid(), GameName = "Red Dead Redemption 2", GameGenre = "Adventure", GameReleaseYear = 2018, GamePublisher = "Rockstar", GameText = "English, Spanish", GameSound = "Surround 5.1" },
                new Game {Id = Guid.NewGuid(), GameName = "Elden Ring", GameGenre = "Action RPG", GameReleaseYear = 2022, GamePublisher = "FromSoftware", GameText = "English, Japanese", GameSound = "3D Audio" },
                new Game {Id = Guid.NewGuid(), GameName = "Call of Duty: Warzone", GameGenre = "FPS", GameReleaseYear = 2020, GamePublisher = "Activision", GameText = "Multi-language", GameSound = "Dolby Digital" },
                new Game {Id = Guid.NewGuid(), GameName = "FIFA 23", GameGenre = "Sports", GameReleaseYear = 2022, GamePublisher = "EA Sports", GameText = "Multi-language", GameSound = "Stereo" },
                new Game {Id = Guid.NewGuid(), GameName = "Assassin's Creed Valhalla", GameGenre = "Action RPG", GameReleaseYear = 2020, GamePublisher = "Ubisoft", GameText = "English, French", GameSound = "Surround 7.1" },
                new Game {Id = Guid.NewGuid(),GameName = "Starfield", GameGenre = "RPG", GameReleaseYear = 2023, GamePublisher = "Bethesda", GameText = "English, German", GameSound = "Dolby Atmos" },
                new Game {Id = Guid.NewGuid(), GameName = "God of War: Ragnarök", GameGenre = "Action", GameReleaseYear = 2022, GamePublisher = "Sony", GameText = "English, Nordic", GameSound = "3D Audio" },
                new Game {Id = Guid.NewGuid(), GameName = "Horizon Forbidden West", GameGenre = "Action RPG", GameReleaseYear = 2022, GamePublisher = "Sony", GameText = "English, Dutch", GameSound = "Tempest 3D" }
            };
            modelBuilder.Entity<Game>().HasData(games);
            // Генерация системных требований
            var systemRequirements = new SystemRequirement[]
            {
                new SystemRequirement { GameId = games[0].Id, Windows = "Windows 10 64-bit", Processor = "Intel Core i7-4790", Memory = "16 GB", VideoCard = "NVIDIA GTX 1060", DiskSpace = "70 GB" },
                new SystemRequirement { GameId = games[1].Id, Windows = "Windows 7 64-bit", Processor = "Intel Core i5-2500K", Memory = "8 GB", VideoCard = "NVIDIA GTX 660", DiskSpace = "35 GB" },
                new SystemRequirement { GameId = games[2].Id, Windows = "Windows 10 64-bit", Processor = "Intel Core i7-4770K", Memory = "12 GB", VideoCard = "NVIDIA GTX 1060", DiskSpace = "150 GB" },
                new SystemRequirement { GameId = games[3].Id, Windows = "Windows 10 64-bit", Processor = "Intel Core i5-8400", Memory = "12 GB", VideoCard = "NVIDIA GTX 1060", DiskSpace = "60 GB" },
                new SystemRequirement { GameId = games[4].Id, Windows = "Windows 10 64-bit", Processor = "Intel Core i5-2500K", Memory = "8 GB", VideoCard = "NVIDIA GTX 670", DiskSpace = "175 GB" },
                new SystemRequirement { GameId = games[5].Id, Windows = "Windows 10 64-bit", Processor = "Intel Core i5-3550", Memory = "8 GB", VideoCard = "NVIDIA GTX 660", DiskSpace = "50 GB" },
                new SystemRequirement { GameId = games[6].Id, Windows = "Windows 10 64-bit", Processor = "Intel Core i5-4460", Memory = "8 GB", VideoCard = "NVIDIA GTX 960", DiskSpace = "130 GB" },
                new SystemRequirement { GameId = games[7].Id, Windows = "Windows 10 64-bit", Processor = "Intel Core i7-6800K", Memory = "16 GB", VideoCard = "NVIDIA RTX 2080", DiskSpace = "125 GB" },
                new SystemRequirement { GameId = games[8].Id, Windows = "Windows 10 64-bit", Processor = "Intel Core i5-6600K", Memory = "8 GB", VideoCard = "NVIDIA GTX 1060", DiskSpace = "110 GB" },
                new SystemRequirement { GameId = games[9].Id, Windows = "Windows 10 64-bit", Processor = "Intel Core i5-2500K", Memory = "8 GB", VideoCard = "NVIDIA GTX 780", DiskSpace = "100 GB" }
            };
            modelBuilder.Entity<SystemRequirement>().HasData(systemRequirements);
        }
    }
}
