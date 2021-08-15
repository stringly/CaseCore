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
    }
}
