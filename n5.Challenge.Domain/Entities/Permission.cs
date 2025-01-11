using System.ComponentModel.DataAnnotations;

namespace n5.Challenge.Domain.Entities
{
    public class Permission
    {
        public int Id { get; set; }

        [Required]
        public required string EmployeeName { get; set; }

        [Required]
        public required string EmployeeSurname { get; set; }

        [Required]
        public int PermissionTypeId { get; set; }

        public virtual PermissionType PermissionType { get; set; }

        [Required]
        public DateTime PermissionDate { get; set; }
    }

}
