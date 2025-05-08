using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameShop_Api.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Games",
                columns: new[] { "Id", "GameGenre", "GameName", "GamePublisher", "GameReleaseYear", "GameSound", "GameText" },
                values: new object[,]
                {
                    { new Guid("0f20c940-e5e1-45b3-aead-0a3e9a7fd975"), "Action RPG", "Elden Ring", "FromSoftware", 2022, "3D Audio", "English, Japanese" },
                    { new Guid("1c4b2866-7e75-409c-8120-92e58b12fe2e"), "Adventure", "Red Dead Redemption 2", "Rockstar", 2018, "Surround 5.1", "English, Spanish" },
                    { new Guid("50fc477b-c367-43d9-81bd-0c02a0374d68"), "Sports", "FIFA 23", "EA Sports", 2022, "Stereo", "Multi-language" },
                    { new Guid("5b24fe7a-3017-43cd-a04b-1b39ab539b12"), "RPG", "Cyberpunk 2077", "CD Projekt Red", 2020, "Dolby Atmos", "English, Russian" },
                    { new Guid("6b8fe026-ad2f-4131-b100-0800606d5a8e"), "FPS", "Call of Duty: Warzone", "Activision", 2020, "Dolby Digital", "Multi-language" },
                    { new Guid("7f153b6f-ef0c-43f3-b502-e9d899a328ac"), "RPG", "Starfield", "Bethesda", 2023, "Dolby Atmos", "English, German" },
                    { new Guid("9eeac66e-4847-4823-a6fb-722b4bea0901"), "Action", "God of War: Ragnarök", "Sony", 2022, "3D Audio", "English, Nordic" },
                    { new Guid("cb17d42b-30a6-4f71-9a40-e05bcb80e251"), "RPG", "The Witcher 3", "CD Projekt Red", 2015, "Stereo", "English, Polish" },
                    { new Guid("e0bffd72-465f-4aab-b20b-2b8ac91a56a0"), "Action RPG", "Horizon Forbidden West", "Sony", 2022, "Tempest 3D", "English, Dutch" },
                    { new Guid("f87557fc-d42b-436c-b7ce-5ba59a5f739f"), "Action RPG", "Assassin's Creed Valhalla", "Ubisoft", 2020, "Surround 7.1", "English, French" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Age", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("23e49b91-a4b3-43a1-913e-24b834713aff"), 22, "Alex", "Johnson" },
                    { new Guid("2942521a-3d9b-4415-80cb-7131f455fdaf"), 31, "David", "Garcia" },
                    { new Guid("2cdebf44-dfa0-4d7a-b3e7-b24323aca631"), 30, "Jane", "Smith" },
                    { new Guid("3ab8f3a5-a871-43e0-854c-2f2e9a1230b4"), 28, "Emily", "Williams" },
                    { new Guid("666b3c81-5fcf-4e92-a3f2-78793a8a7964"), 24, "Jessica", "Miller" },
                    { new Guid("78732329-0d63-4cba-a98b-eab0ec4865e9"), 29, "Daniel", "Davis" },
                    { new Guid("84e85dc6-782a-4ed9-826b-66f04bb7ed78"), 27, "Sarah", "Jones" },
                    { new Guid("8c918250-4ff1-49a5-9991-d207dbd8ccf6"), 26, "Olivia", "Rodriguez" },
                    { new Guid("b9602d9a-5be7-4469-9c2b-238f47e111da"), 25, "John", "Doe" },
                    { new Guid("baca81f5-2f38-4677-9bdd-ba0c11bbee62"), 35, "Michael", "Brown" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "System-Requirements",
                columns: new[] { "GameId", "DiskSpace", "Memory", "Processor", "VideoCard", "Windows" },
                values: new object[,]
                {
                    { new Guid("0f20c940-e5e1-45b3-aead-0a3e9a7fd975"), "60 GB", "12 GB", "Intel Core i5-8400", "NVIDIA GTX 1060", "Windows 10 64-bit" },
                    { new Guid("1c4b2866-7e75-409c-8120-92e58b12fe2e"), "150 GB", "12 GB", "Intel Core i7-4770K", "NVIDIA GTX 1060", "Windows 10 64-bit" },
                    { new Guid("50fc477b-c367-43d9-81bd-0c02a0374d68"), "50 GB", "8 GB", "Intel Core i5-3550", "NVIDIA GTX 660", "Windows 10 64-bit" },
                    { new Guid("5b24fe7a-3017-43cd-a04b-1b39ab539b12"), "70 GB", "16 GB", "Intel Core i7-4790", "NVIDIA GTX 1060", "Windows 10 64-bit" },
                    { new Guid("6b8fe026-ad2f-4131-b100-0800606d5a8e"), "175 GB", "8 GB", "Intel Core i5-2500K", "NVIDIA GTX 670", "Windows 10 64-bit" },
                    { new Guid("7f153b6f-ef0c-43f3-b502-e9d899a328ac"), "125 GB", "16 GB", "Intel Core i7-6800K", "NVIDIA RTX 2080", "Windows 10 64-bit" },
                    { new Guid("9eeac66e-4847-4823-a6fb-722b4bea0901"), "110 GB", "8 GB", "Intel Core i5-6600K", "NVIDIA GTX 1060", "Windows 10 64-bit" },
                    { new Guid("cb17d42b-30a6-4f71-9a40-e05bcb80e251"), "35 GB", "8 GB", "Intel Core i5-2500K", "NVIDIA GTX 660", "Windows 7 64-bit" },
                    { new Guid("e0bffd72-465f-4aab-b20b-2b8ac91a56a0"), "100 GB", "8 GB", "Intel Core i5-2500K", "NVIDIA GTX 780", "Windows 10 64-bit" },
                    { new Guid("f87557fc-d42b-436c-b7ce-5ba59a5f739f"), "130 GB", "8 GB", "Intel Core i5-4460", "NVIDIA GTX 960", "Windows 10 64-bit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "System-Requirements",
                keyColumn: "GameId",
                keyValue: new Guid("0f20c940-e5e1-45b3-aead-0a3e9a7fd975"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "System-Requirements",
                keyColumn: "GameId",
                keyValue: new Guid("1c4b2866-7e75-409c-8120-92e58b12fe2e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "System-Requirements",
                keyColumn: "GameId",
                keyValue: new Guid("50fc477b-c367-43d9-81bd-0c02a0374d68"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "System-Requirements",
                keyColumn: "GameId",
                keyValue: new Guid("5b24fe7a-3017-43cd-a04b-1b39ab539b12"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "System-Requirements",
                keyColumn: "GameId",
                keyValue: new Guid("6b8fe026-ad2f-4131-b100-0800606d5a8e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "System-Requirements",
                keyColumn: "GameId",
                keyValue: new Guid("7f153b6f-ef0c-43f3-b502-e9d899a328ac"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "System-Requirements",
                keyColumn: "GameId",
                keyValue: new Guid("9eeac66e-4847-4823-a6fb-722b4bea0901"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "System-Requirements",
                keyColumn: "GameId",
                keyValue: new Guid("cb17d42b-30a6-4f71-9a40-e05bcb80e251"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "System-Requirements",
                keyColumn: "GameId",
                keyValue: new Guid("e0bffd72-465f-4aab-b20b-2b8ac91a56a0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "System-Requirements",
                keyColumn: "GameId",
                keyValue: new Guid("f87557fc-d42b-436c-b7ce-5ba59a5f739f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("23e49b91-a4b3-43a1-913e-24b834713aff"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2942521a-3d9b-4415-80cb-7131f455fdaf"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2cdebf44-dfa0-4d7a-b3e7-b24323aca631"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3ab8f3a5-a871-43e0-854c-2f2e9a1230b4"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("666b3c81-5fcf-4e92-a3f2-78793a8a7964"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("78732329-0d63-4cba-a98b-eab0ec4865e9"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("84e85dc6-782a-4ed9-826b-66f04bb7ed78"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8c918250-4ff1-49a5-9991-d207dbd8ccf6"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9602d9a-5be7-4469-9c2b-238f47e111da"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("baca81f5-2f38-4677-9bdd-ba0c11bbee62"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("0f20c940-e5e1-45b3-aead-0a3e9a7fd975"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("1c4b2866-7e75-409c-8120-92e58b12fe2e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("50fc477b-c367-43d9-81bd-0c02a0374d68"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("5b24fe7a-3017-43cd-a04b-1b39ab539b12"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("6b8fe026-ad2f-4131-b100-0800606d5a8e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("7f153b6f-ef0c-43f3-b502-e9d899a328ac"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("9eeac66e-4847-4823-a6fb-722b4bea0901"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("cb17d42b-30a6-4f71-9a40-e05bcb80e251"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("e0bffd72-465f-4aab-b20b-2b8ac91a56a0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("f87557fc-d42b-436c-b7ce-5ba59a5f739f"));
        }
    }
}
