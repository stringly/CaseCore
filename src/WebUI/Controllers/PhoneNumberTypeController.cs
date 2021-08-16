using CaseCore.Application.PhoneNumberTypes.Commands.DeletePhoneNumberType;
using CaseCore.Application.PhoneNumberTypes.Commands.UpsertPhoneNumberType;
using CaseCore.Application.PhoneNumberTypes.Queries.GetPhoneNumberTypeDetail;
using CaseCore.Application.PhoneNumberTypes.Queries.GetPhoneNumberTypeList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CaseCore.WebUI.Controllers
{
    /// <summary>
    /// Controller that handles CRUD for the Phone Number Type entity.
    /// </summary>
    [Authorize]
    [ApiController]
    public class PhoneNumberTypeController : BaseController
    {
        /// <summary>
        /// Returns a list of Phone Number Types
        /// </summary>
        /// <param name="query">An instance of <see cref="GetPhoneNumberTypeListQuery"/> assembled from the query parameters.</param>
        /// <returns></returns>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]

        public async Task<ActionResult<PhoneNumberTypeListVm>> GetAll([FromQuery] GetPhoneNumberTypeListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        /// <summary>
        /// Returns a detailed view of a specific Phone Number Types.
        /// </summary>
        /// <param name="query">An <see cref="GetPhoneNumberTypeDetailQuery"/> bound from the querystring.</param>
        /// <returns>A <see cref="PhoneNumberTypeDetailVm"/> containing the details of the requested address.</returns>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<PhoneNumberTypeDetailVm>> Get([FromQuery] GetPhoneNumberTypeDetailQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        /// <summary>
        /// Creates or Updates an Phone Number Type.
        /// </summary>
        /// <param name="command">An <see cref="UpsertPhoneNumberTypeCommand"/> object.</param>
        /// <returns>An integer Id of the upserted Phone Number Type.</returns>
        /// <remarks>
        /// This method will update an Person Type if the Id parameter is provided. If no Id parameter is present, the method will create a new Phone Number Type.
        /// </remarks>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> Upsert(UpsertPhoneNumberTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Deletes an Phone Number Type.
        /// </summary>
        /// <param name="command">A <see cref="DeletePhoneNumberTypeCommand"/>.</param>
        /// <returns></returns>
        [HttpDelete]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> Delete([FromQuery] DeletePhoneNumberTypeCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
