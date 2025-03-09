using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Customers;
using Microsoft.AspNetCore.Mvc;

namespace InventifyBackend.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        ///<summary>Add a new customer</summary>
        ///<param name="customer">Customer model to create a Customer</param>
        ///<returns>Return user created</returns>
        ///<response code="200">Return when is created a customer</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto<Guid>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Add(CustomerCreateResource customer, CancellationToken cancellationToken)
        {
            ResponseDto<Guid> response = await _customerService.Add(customer, cancellationToken);

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

        ///<summary>Get customer by id</summary>
        ///<param name="id">Id to search the customer</param>
        ///<returns>Return the customer</returns>
        ///<response code="200">Return when get customer</response>
        ///<response code="400">Wrong return</response>
        ///<response code="500">Internal error on server</response>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseDto<List<CustomerDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            ResponseDto<CustomerDto>? response = await _customerService.Get(id, cancellationToken);

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

        ///<summary>Get all customers</summary>
        ///<returns>Return the customer</returns>
        ///<response code="200">Return when get customer</response>
        ///<response code="400">Wrong return</response>
        ///<response code="500">Internal error on server</response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(ResponseDto<List<CustomerDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            ResponseDto<IEnumerable<CustomerDto>> response = await _customerService.GetAll(cancellationToken);

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

        ///<summary>Update a customer</summary>
        ///<param name="customerUpdateResource">Customer model to update a Customer</param>
        ///<returns>Return customer updated</returns>
        ///<response code="200">Return when is updated a customer</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseDto<CustomerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Update(CustomerUpdateResource customerUpdateResource, CancellationToken cancellationToken)
        {
            ResponseDto<CustomerDto> response = await _customerService.Update(customerUpdateResource, cancellationToken);

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

        ///<summary>Delete a customer</summary>
        ///<param name="id">Customer id to delete this user</param>
        ///<response code="200">Return when delete a customer successfully</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            ResponseDto<Guid> response = await _customerService.Delete(id, cancellationToken);

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
