using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventifyBackend.Api.Controllers
{
    [Route("api/[controller]")]
    // [Authorize]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        ///<summary>Add a new category</summary>
        ///<param name="category">Category model to create a category</param>
        ///<returns>Return user created</returns>
        ///<response code="200">Return when is created a category</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto<Guid>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Add(CategoryCreateResource category, CancellationToken cancellationToken)
        {
            ResponseDto<Guid> response = await _categoryService.Add(category, cancellationToken);

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

        ///<summary>Get category by id</summary>
        ///<param name="id">Id to search the category</param>
        ///<returns>Return the category</returns>
        ///<response code="200">Return when get category</response>
        ///<response code="400">Wrong return</response>
        ///<response code="500">Internal error on server</response>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseDto<List<CategoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            ResponseDto<CategoryDto>? response = await _categoryService.Get(id, cancellationToken);

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

        /// <summary>Get all categories</summary>
        /// <returns>Return all categories</returns>
        /// <response code="200">Return when categories are retrieved successfully</response>
        /// <response code="500">Internal error on server</response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CategoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await _categoryService.GetAll(cancellationToken);

            return response.StatusCode == StatusCodes.Status200OK ? Ok(response) : StatusCode(response.StatusCode, response);
        }

        ///<summary>Update a category</summary>
        ///<param name="categoryResource">Category model to update a category</param>
        ///<returns>Return category updated</returns>
        ///<response code="200">Return when is updated a category</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseDto<CategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Update(CategoryUpdateResource? categoryResource,
            CancellationToken cancellationToken)
        {
            ResponseDto<CategoryDto> response = await _categoryService.Update(categoryResource, cancellationToken);

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

        ///<summary>Delete a category</summary>
        ///<param name="id">Category id to delete this user</param>
        ///<response code="200">Return when delete a category successfully</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            ResponseDto<Guid> response = await _categoryService.Delete(id, cancellationToken);

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