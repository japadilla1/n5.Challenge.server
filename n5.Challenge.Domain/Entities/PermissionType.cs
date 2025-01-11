using System.ComponentModel.DataAnnotations;

namespace n5.Challenge.Domain.Entities
{
    public class PermissionType
    {
        public int Id { get; set; }

        [Required]
        public required string Description { get; set; }
    }
}
