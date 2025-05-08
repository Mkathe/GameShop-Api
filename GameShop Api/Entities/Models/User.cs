using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameShop_Api.Entities.Models
{
    [Table("Users", Schema = "dbo")]
    public class User : BaseEntity
    {
        [StringLength(50, ErrorMessage = "Max is 50 chars")]
        public required string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "Max is 50 chars")]
        public required string LastName { get; set; }
        [Range(0, 150)]
        public int? Age { get; set; }
    }
}
