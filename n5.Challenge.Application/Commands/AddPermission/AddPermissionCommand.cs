using MediatR;
using System.ComponentModel.DataAnnotations;

namespace n5.Challenge.Application.Commands.AddPermission
{
    public class AddPermissionCommand: IRequest<bool>
    {
        public int Id { get; set; }

        [Required]
        public required string EmployeeName { get; set; }

        [Required]
        public required string EmployeeSurname { get; set; }

        [Required]
        public int PermissionTypeId { get; set; }

        [Required]
        public DateTime PermissionDate { get; set; }
    }
}
