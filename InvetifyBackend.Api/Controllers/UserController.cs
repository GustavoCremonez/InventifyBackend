using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventifyBackend.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        ///<summary>Add a new user</summary>
        /// <param name="cancellationToken">Token to cancellation operation</param>
        ///<param name="user">User model to create a user</param>
        ///<returns>Return user created</returns>
        ///<response code="200">Return when is created a user</response>
        ///<response code="400">Wrong information</response>
        ///<response code="500">Internal error on server</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto<Guid>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Add(UserCreateResource user, CancellationToken cancellationToken)
        {
            ResponseDto<Guid> response = await userService.Add(user, cancellationToken);

            return response.StatusCode switch
            {
                StatusCodes.Status200OK => Ok(response),
                StatusCodes.Status400BadRequest => BadRequest(response),
                _ => StatusCode(response.StatusCode, response)
            };
        }

        ///<summary>Get user by email</summary>
        /// <param name="cancellationToken">Token to cancellation operation</param>
        ///<param name="email">Email to search the user</param>
        ///<returns>Return the user</returns>
        ///<response code="200">Return when get user</response>
        ///<response code="400">Wrong return</response>
        ///<response code="500">Internal error on server</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Get(string email, CancellationToken cancellationToken)
        {
            ResponseDto<UserDto>? response = await userService.GetAbstracted(email, cancellationToken);

            return response.StatusCode switch
            {
                StatusCodes.Status200OK => Ok(response),
                StatusCodes.Status400BadRequest => BadRequest(response),
                _ => StatusCode(response.StatusCode, response)
            };
        }

        ///<summary>Update a user</summary>
        /// <param name="cancellationToken">Token to cancellation operation</param>
        ///<param name="userResource">User model to update a user</param>
        ///<returns>Return user updated</returns>
        ///<response code="200">Return when is updated a user</response>
        ///<response code="400">Wrong information</response>
        ///<response code="500">Internal error on server</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(typeof(ResponseDto<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Update(UserUpdateResource userResource, CancellationToken cancellationToken)
        {
            ResponseDto<UserDto> response = await userService.Update(userResource, cancellationToken);

            return response.StatusCode switch
            {
                StatusCodes.Status200OK => Ok(response),
                StatusCodes.Status400BadRequest => BadRequest(response),
                _ => StatusCode(response.StatusCode, response)
            };
        }

        /// <summary>Delete a user</summary>
        /// <param name="email">User email to delete this user</param>
        /// <param name="cancellationToken">Token to cancellation operation</param>
        /// <response code="200">Return when delete a user successfully</response>
        /// <response code="400">Wrong information</response>
        /// <response code="500">Internal error on server</response>
        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Delete(string email, CancellationToken cancellationToken)
        {
            ResponseDto<Guid> response = await userService.Delete(email, cancellationToken);

            return response.StatusCode switch
            {
                StatusCodes.Status200OK => Ok(response),
                StatusCodes.Status400BadRequest => BadRequest(response),
                _ => StatusCode(response.StatusCode, response)
            };
        }
    }
}
