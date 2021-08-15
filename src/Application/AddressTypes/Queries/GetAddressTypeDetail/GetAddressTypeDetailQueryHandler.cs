using AutoMapper;
using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Domain.Types;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.AddressTypes.Queries.GetAddressTypeDetail
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests for details of a <see cref="Domain.Types.AddressType"></see>
    /// </summary>
    public class GetAddressTypeDetailQueryHandler : IRequestHandler<GetAddressTypeDetailQuery, AddressTypeDetailVm>
    {
        private readonly ICaseCoreDbContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        public GetAddressTypeDetailQueryHandler(ICaseCoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request">A <see cref="GetAddressTypeDetailQuery"/> object.</param>
        /// <param name="cancellationToken">A CancellationToken</param>
        /// <returns>A <see cref="AddressTypeDetailVm"/> containing the Address Type Details.</returns>
        /// <exception cref="NotFoundException">Thrown when no Address Type with the provided Id was found.</exception>
        public async Task<AddressTypeDetailVm> Handle(GetAddressTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.AddressTypes.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(AddressType), request.Id);
            }
            var vm = new AddressTypeDetailVm
            {
                AddressType = _mapper.Map<AddressTypeDto>(entity)
            };
            return vm;
        }
    }
}
