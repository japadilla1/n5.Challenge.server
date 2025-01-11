using MediatR;
using Microsoft.AspNetCore.Mvc;
using n5.Challenge.Application.Commands.AddPermission;
using n5.Challenge.Application.Commands.UpdatePermission;
using n5.Challenge.Application.Queries.GetAllPermission;

namespace n5.Challenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController(IMediator mediator, ILogger<PermissionController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<PermissionController> _logger = logger;

        [HttpGet]
        [Route("permission/get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = new GetAllPermissionQuery();

                var response = await _mediator.Send(query);

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error {e.StackTrace}");
                return StatusCode(500, "Ocurrió un problema al procesar la petición");
            }
        }

        [HttpPost]
        [Route("permission/add")]
        public async Task<IActionResult> AddPermission(AddPermissionCommand input)
        {
            try
            {

                var response = await _mediator.Send(input);
                return Ok(response);

            }
            catch (Exception e)
            {
                _logger.LogError($"Error {e.StackTrace}");
                return StatusCode(500, "Ocurrió un problema al procesar la petición");
            }
        }


        [HttpPut]
        [Route("permission/update")]
        public async Task<IActionResult> UpdatePermission(UpdatePermissionCommand input)
        {
            try
            {

                var response = await _mediator.Send(input);
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
