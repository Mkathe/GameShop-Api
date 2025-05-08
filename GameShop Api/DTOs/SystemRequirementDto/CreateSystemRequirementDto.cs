using System.ComponentModel.DataAnnotations;

namespace GameShop_Api.DTOs.SystemRequirementDto
{
    public class CreateSystemRequirementDto
    {
        public Guid GameId { get; set; }
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
