using CaseCore.Application.PersonTypes.Commands.DeletePersonType;
using CaseCore.Application.PersonTypes.Commands.UpsertPersonType;
using CaseCore.Application.PersonTypes.Queries.GetPersonTypeDetail;
using CaseCore.Application.PersonTypes.Queries.GetPersonTypeList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CaseCore.WebUI.Controllers
{
    /// <summary>
    /// Controller that handles CRUD for the Person Type entity.
    /// </summary>
    [Authorize]
    [ApiController]
    public class PersonTypeController : BaseController
    {
        /// <summary>
        /// Returns a list of Person Types
        /// </summary>
        /// <param name="query">An instance of <see cref="GetPersonTypeListQuery"/> assembled from the query parameters.</param>
        /// <returns></returns>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]

        public async Task<ActionResult<PersonTypeListVm>> GetAll([FromQuery] GetPersonTypeListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        /// <summary>
        /// Returns a detailed view of a specific Person Type.
        /// </summary>
        /// <param name="query">An <see cref="GetPersonTypeDetailQuery"/> bound from the querystring.</param>
        /// <returns>A <see cref="PersonTypeDetailVm"/> containing the details of the requested address.</returns>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<PersonTypeDetailVm>> Get([FromQuery] GetPersonTypeDetailQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        /// <summary>
        /// Creates or Updates an Person Type.
        /// </summary>
        /// <param name="command">An <see cref="UpsertPersonTypeCommand"/> object.</param>
        /// <returns>An integer Id of the upserted Person Type.</returns>
        /// <remarks>
        /// This method will update an Person Type if the Id parameter is provided. If no Id parameter is present, the method will create a new Person Type.
        /// </remarks>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> Upsert(UpsertPersonTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Deletes an Person Type.
        /// </summary>
        /// <param name="command">A <see cref="DeletePersonTypeCommand"/>.</param>
        /// <returns></returns>
        [HttpDelete]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> Delete([FromQuery] DeletePersonTypeCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
