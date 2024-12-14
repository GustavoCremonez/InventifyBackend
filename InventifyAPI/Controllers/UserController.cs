using Inventify.Application.Dtos;
using Inventify.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public UserController(IUserService userService, ILogger logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                UserDto user = await _userService.GetByIdAsync(id);

                if (user == null)
                {
                    return NotFound(ApiResponse<UserDto>.FailureResponse("User not found"));
                }

                return Ok(ApiResponse<UserDto>.SuccessResponse(user));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while getting user with ID: {id}", ex);
                return StatusCode(500, ApiResponse<UserDto>.FailureResponse($"An error occurred: {ex.Message}"));
            }
        }
    }
}
