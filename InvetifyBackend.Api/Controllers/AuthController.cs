using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Login;
using InventifyBackend.Application.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace InventifyBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        ///<summary>Authenticate user</summary>
        ///<param name="resource">Resource to process login</param>
        ///<returns>Return user created</returns>
        ///<response code="200">Return when is authorized user</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Login([FromBody] UserResource resource, CancellationToken cancellationToken)
        {
            ResponseDto<object> response = await _authService.LoginAsync(resource, cancellationToken);

            if (response.StatusCode == StatusCodes.Status200OK)
            {
                return Ok(response);
            }
            else if (response.StatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(response);
            }
            else
            {
                return StatusCode(response.StatusCode, response);
            }
        }
    }
}
