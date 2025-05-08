using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameShop_Api.Entities.Models
{
    [Table("Games", Schema = "dbo")]
    public class Game : BaseEntity
    {
        [StringLength(50, ErrorMessage = "Max is 50 chars")]
        public required string GameName { get; set; }
        [StringLength(20, ErrorMessage = "Max is 20 chars")]
        public required string GameGenre { get; set; }
        [Range(1900, 2500, ErrorMessage = "Range is 4-5 ints")]
        public int? GameReleaseYear { get; set; }
        [StringLength(20, ErrorMessage = "Max is 20 chars")]
        public required string GamePublisher { get; set; }
        [StringLength(50, ErrorMessage = "Max is 50 chars")]
        public required string GameText { get; set; }
        [StringLength(50, ErrorMessage = "Max is 50 chars")]
        public required string GameSound { get; set; }
        [InverseProperty(nameof(SystemRequirement.GameNavigation))]
        public SystemRequirement SystemRequirementNavigation { get; set; }

    }
}
