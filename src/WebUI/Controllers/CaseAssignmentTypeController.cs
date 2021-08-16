using CaseCore.Application.CaseAssignmentTypes.Commands.DeleteCaseAssignmentType;
using CaseCore.Application.CaseAssignmentTypes.Commands.UpsertCaseAssignmentType;
using CaseCore.Application.CaseAssignmentTypes.Queries.GetCaseAssignmentTypeDetail;
using CaseCore.Application.CaseAssignmentTypes.Queries.GetCaseAssignmentTypeList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CaseCore.WebUI.Controllers
{
    /// <summary>
    /// Controller that handles CRUD for the CaseAssignmentType entity.
    /// </summary>
    [Authorize]
    [ApiController]
    public class CaseAssignmentTypeController : BaseController
    {
        /// <summary>
        /// Returns a list of CaseAssignmentType
        /// </summary>
        /// <param name="query">An instance of <see cref="GetCaseAssignmentTypeListQuery"/> assembled from the query parameters.</param>
        /// <returns>A <see cref="CaseAssignmentTypeListVm"/> containing the lsit of items.</returns>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<CaseAssignmentTypeListVm>> GetAll([FromQuery] GetCaseAssignmentTypeListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        /// <summary>
        /// Returns a detailed view of a specific AddressType.
        /// </summary>
        /// <param name="id">The integer Id of the desired CaseAssignmentType.</param>
        /// <returns>A <see cref="CaseAssignmentTypeDetailVm"/> containing the details of the requested address.</returns>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<CaseAssignmentTypeDetailVm>> Get([FromQuery] GetCaseAssignmentTypeDetailQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        /// <summary>
        /// Creates or Updates an CaseAssignmentType.
        /// </summary>
        /// <param name="command">An <see cref="UpsertCaseAssignmentTypeCommand"/> object.</param>
        /// <returns>An integer Id of the upserted CaseAssignmentType.</returns>
        /// <remarks>
        /// This method will update a CaseAssignmentType if the Id parameter is provided. If no Id parameter is present, the method will create a new CaseAssignmentType.
        /// </remarks>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> Upsert([FromBody] UpsertCaseAssignmentTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Deletes a Case Assignment Type.
        /// </summary>
        /// <param name="command">A <see cref="DeleteCaseAssignmentTypeCommand"/> created from the querystring.</param>
        /// <returns></returns>
        [HttpDelete]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> Delete([FromQuery] DeleteCaseAssignmentTypeCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
