using MediatR;
using Microsoft.AspNetCore.Mvc;
using n5.Challenge.Application.Queries.GetAllPermissionType;

namespace n5.Challenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionTypeController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        [Route("permission/get-all")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPermissionTypeQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
