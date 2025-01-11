using MediatR;
using n5.Challenge.Application.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n5.Challenge.Application.Commands.UpdatePermission
{
    public class UpdatePermissionCommand: IRequest<PermissionDto>
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
