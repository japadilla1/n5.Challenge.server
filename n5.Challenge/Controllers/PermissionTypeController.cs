using MediatR;
using Microsoft.AspNetCore.Mvc;
using n5.Challenge.Application.Queries.GetAllPermissionType;

namespace n5.Challenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionTypeController(IMediator mediator, ILogger<PermissionTypeController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<PermissionTypeController> _logger = logger;

        [HttpGet]
        [Route("permission/get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = new GetAllPermissionTypeQuery();

                var response = await _mediator.Send(query);

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error {e.StackTrace}");
                return StatusCode(500, "Ocurrió un problema al procesar la petición");
            }
        }
    }
}
