using n5.Challenge.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace n5.Challenge.Application.Dto
{
    public class PermissionDto
    {
        public int Id { get; set; }

        [Required]
        public required string EmployeeName { get; set; }

        [Required]
        public required string EmployeeSurname { get; set; }

        [Required]
        public int PermissionTypeId { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public DateTime PermissionDate { get; set; }
    }
}
