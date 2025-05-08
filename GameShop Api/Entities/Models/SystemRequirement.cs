using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GameShop_Api.Entities.Models
{
    [Table("System-Requirements", Schema = "dbo")]
    public class SystemRequirement
    {
        [ForeignKey(nameof(GameNavigation))]
        public Guid GameId { get; set; }
        [InverseProperty(nameof(Game.SystemRequirementNavigation))]
        [JsonIgnore]
        [IgnoreDataMember]
        public Game GameNavigation { get; set; }
        [StringLength(50, ErrorMessage = "Max is 50 chars")]
        public required string Windows { get; set; }
        [StringLength(50, ErrorMessage = "Max is 50 chars")]
        public required string Processor { get; set; }
        [StringLength(50, ErrorMessage = "Max is 50 chars")]
        public required string Memory { get; set; }
        [StringLength(50, ErrorMessage = "Max is 50 chars")]
        public required string VideoCard { get; set; }
        [StringLength(50, ErrorMessage = "Max is 50 chars")]
        public required string DiskSpace { get; set; }
    }
}
