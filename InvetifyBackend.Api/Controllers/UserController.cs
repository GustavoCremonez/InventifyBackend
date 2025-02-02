using Azure;
using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace InventifyBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        ///<summary>Add a new user</summary>
        ///<param name="user">User model to create a user</param>
        ///<returns>Return user created</returns>
        ///<response code="200">Return when is created a user</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Add(UserCreateResource user, CancellationToken cancellationToken)
        {
            ResponseDto<Guid> response = await _userService.Add(user, cancellationToken);

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

        ///<summary>Get user by email</summary>
        ///<param name="email">Email to search the user</param>
        ///<returns>Return the user</returns>
        ///<response code="200">Return when get user</response>
        ///<response code="400">Wrong return</response>
        ///<response code="500">Internal error on server</response>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Get(string email)
        {
            ResponseDto<UserDto>? response = await _userService.Get(email);

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

        ///<summary>Add a new user</summary>
        ///<param name="userResource">User model to update a user</param>
        ///<returns>Return user updated</returns>
        ///<response code="200">Return when is updated a user</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseDto<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Update(UserUpdateResource userResource)
        {
            ResponseDto<UserDto> response = await _userService.Update(userResource);

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

        ///<summary>Delete a user</summary>
        ///<param name="email">User email to delete this user</param>
        ///<response code="200">Return when delete a user successfully</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Delete(string email)
        {
            ResponseDto<Guid> response = await _userService.Delete(email);

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
