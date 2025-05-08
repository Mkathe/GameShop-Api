using System.ComponentModel.DataAnnotations;

namespace GameShop_Api.DTOs.UserDto
{
    public class CreateUserDto
    {
        [StringLength(50, ErrorMessage = "Max is 50 chars")]
        public required string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "Max is 50 chars")]
        public required string LastName { get; set; }
        [Range(0, 150)]
        public int? Age { get; set; }
    }
}
