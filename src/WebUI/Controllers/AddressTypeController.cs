using CaseCore.Application.AddressTypes.Commands.DeleteAddressType;
using CaseCore.Application.AddressTypes.Commands.UpsertAddressType;
using CaseCore.Application.AddressTypes.Queries.GetAddressTypeDetail;
using CaseCore.Application.AddressTypes.Queries.GetAddressTypeList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaseCore.WebUI.Controllers
{
    /// <summary>
    /// Controller that handles CRUD for the AddressType entity.
    /// </summary>
    [Authorize]
    [ApiController]
    public class AddressTypeController : BaseController
    {
        /// <summary>
        /// Returns a list of AddressTypes
        /// </summary>
        /// <param name="query">An instance of <see cref="GetAddressTypeListQuery"/> assembled from the query parameters.</param>
        /// <returns></returns>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]

        public async Task<ActionResult<AddressTypeListVm>> GetAll([FromQuery] GetAddressTypeListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Returns a detailed view of a specific AddressType.
        /// </summary>
        /// <param name="query">An <see cref="GetAddressTypeDetailQuery"/> bound from the querystring.</param>
        /// <returns>A <see cref="AddressTypeDetailVm"/> containing the details of the requested address.</returns>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<AddressTypeDetailVm>> Get([FromQuery] GetAddressTypeDetailQuery query)
        {
                return Ok(await Mediator.Send(query));
        }
        /// <summary>
        /// Creates or Updates an AddressType.
        /// </summary>
        /// <param name="command">An <see cref="UpsertAddressTypeCommand"/> object.</param>
        /// <returns>An integer Id of the upserted AddressType.</returns>
        /// <remarks>
        /// This method will update an AddressType if the Id parameter is provided. If no Id parameter is present, the method will create a new Address Type.
        /// </remarks>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> Upsert(UpsertAddressTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Deletes an Address Type.
        /// </summary>
        /// <param name="id">The Id of the AddressType to be deleted.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteAddressTypeCommand { Id = id });
            return NoContent();
        }
    }
}
