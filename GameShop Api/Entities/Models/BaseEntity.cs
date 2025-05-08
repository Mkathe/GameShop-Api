using System.ComponentModel.DataAnnotations;

namespace GameShop_Api.Entities.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Timestamp]
        public byte[]? Timestamp { get; set; }
    }
}
