using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos.User;
using InventifyBackend.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InventifyBackend.Application.Dtos.Categories;

namespace InventifyBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly ICategorieService _categorieService;

        public CategorieController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        ///<summary>Add a new categorie</summary>
        ///<param name="categorie">Categorie model to create a categorie</param>
        ///<returns>Return user created</returns>
        ///<response code="200">Return when is created a categorie</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto<Guid>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Add(CategorieCreateResource categorie, CancellationToken cancellationToken)
        {
            ResponseDto<Guid> response = await _categorieService.Add(categorie, cancellationToken);

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

        ///<summary>Get categorie by id</summary>
        ///<param name="id">Id to search the categorie</param>
        ///<returns>Return the categorie</returns>
        ///<response code="200">Return when get categorie</response>
        ///<response code="400">Wrong return</response>
        ///<response code="500">Internal error on server</response>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseDto<List<CategorieDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            ResponseDto<CategorieDto>? response = await _categorieService.Get(id, cancellationToken);

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

        ///<summary>Add a new categorie</summary>
        ///<param name="categorieResource">Categorie model to update a categorie</param>
        ///<returns>Return categorie updated</returns>
        ///<response code="200">Return when is updated a categorie</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseDto<CategorieDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Update(CategorieUpdateResource categorieResource, CancellationToken cancellationToken)
        {
            ResponseDto<CategorieDto> response = await _categorieService.Update(categorieResource, cancellationToken);

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

        ///<summary>Delete a categorie</summary>
        ///<param name="id">Categorie id to delete this user</param>
        ///<response code="200">Return when delete a categorie successfully</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            ResponseDto<Guid> response = await _categorieService.Delete(id, cancellationToken);

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
