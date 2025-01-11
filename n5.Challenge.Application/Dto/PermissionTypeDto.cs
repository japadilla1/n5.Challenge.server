using System.ComponentModel.DataAnnotations;

namespace n5.Challenge.Application.Dto
{
    public class PermissionTypeDto
    {
        public int Id { get; set; }

        [Required]
        public required string Description { get; set; }
    }
}
