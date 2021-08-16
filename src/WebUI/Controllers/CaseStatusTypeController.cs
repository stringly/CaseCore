using CaseCore.Application.CaseStatusTypes.Commands.DeleteCaseStatusType;
using CaseCore.Application.CaseStatusTypes.Commands.UpsertCaseStatusType;
using CaseCore.Application.CaseStatusTypes.Queries.GetCaseStatusTypeDetail;
using CaseCore.Application.CaseStatusTypes.Queries.GetCaseStatusTypeList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CaseCore.WebUI.Controllers
{
    /// <summary>
    /// Controller that handles CRUD for the Case Status entity.
    /// </summary>
    [Authorize]
    [ApiController]
    public class CaseStatusTypeController : BaseController
    {
        /// <summary>
        /// Returns a list of Case Statuses
        /// </summary>
        /// <param name="query">An instance of <see cref="GetCaseStatusTypeListQuery"/> assembled from the query parameters.</param>
        /// <returns></returns>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]

        public async Task<ActionResult<CaseStatusTypeListVm>> GetAll([FromQuery] GetCaseStatusTypeListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        /// <summary>
        /// Returns a detailed view of a specific Case Status.
        /// </summary>
        /// <param name="query">An <see cref="GetCaseStatusTypeDetailQuery"/> bound from the querystring.</param>
        /// <returns>A <see cref="CaseStatusTypeDetailVm"/> containing the details of the requested Case Status.</returns>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<CaseStatusTypeDetailVm>> Get([FromQuery] GetCaseStatusTypeDetailQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        /// <summary>
        /// Creates or Updates a Case Status Type.
        /// </summary>
        /// <param name="command">An <see cref="UpsertCaseStatusTypeCommand"/> object.</param>
        /// <returns>An integer Id of the upserted Case Status Type.</returns>
        /// <remarks>
        /// This method will update an Case Status Type if the Id parameter is provided. If no Id parameter is present, the method will create a new Case Status Type.
        /// </remarks>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> Upsert(UpsertCaseStatusTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Deletes a Case Status Type.
        /// </summary>
        /// <param name="command">A <see cref="DeleteCaseStatusTypeCommand"/> created from the querystring.</param>
        /// <returns></returns>
        [HttpDelete]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> Delete([FromQuery] DeleteCaseStatusTypeCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
