using MediatR;
using Microsoft.AspNetCore.Mvc;
using n5.Challenge.Application.Commands.AddPermission;
using n5.Challenge.Application.Commands.UpdatePermission;
using n5.Challenge.Application.Queries.GetAllPermission;

namespace n5.Challenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [Route("permission/get-all")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPermissionQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        [Route("permission/add")]
        public async Task<IActionResult> AddPermission(AddPermissionCommand input)
        {
            var response = await _mediator.Send(input);
            return Ok(response);
        }


        [HttpPut]
        [Route("permission/update")]
        public async Task<IActionResult> UpdatePermission(UpdatePermissionCommand input)
        {
            var response = await _mediator.Send(input);
            return Ok(response);
        }
    }
}
