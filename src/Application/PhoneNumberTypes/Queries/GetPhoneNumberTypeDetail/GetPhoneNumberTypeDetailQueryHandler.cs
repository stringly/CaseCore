using AutoMapper;
using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Domain.Types;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.PhoneNumberTypes.Queries.GetPhoneNumberTypeDetail
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests for details of a <see cref="Domain.Types.PhoneNumberType"></see>
    /// </summary>
    public class GetPhoneNumberTypeDetailQueryHandler : IRequestHandler<GetPhoneNumberTypeDetailQuery, PhoneNumberTypeDetailVm>
    {
        private readonly ICaseCoreDbContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        public GetPhoneNumberTypeDetailQueryHandler(ICaseCoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request">A <see cref="GetPhoneNumberTypeDetailQuery"/> object.</param>
        /// <param name="cancellationToken">A CancellationToken</param>
        /// <returns>A <see cref="PhoneNumberTypeDetailVm"/> containing the Phone Number Type Details.</returns>
        /// <exception cref="NotFoundException">Thrown when no Phone Number Type with the provided Id was found.</exception>
        public async Task<PhoneNumberTypeDetailVm> Handle(GetPhoneNumberTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.PhoneNumberTypes.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(PhoneNumberType), request.Id);
            }
            var vm = new PhoneNumberTypeDetailVm
            {
                PhoneNumberType = _mapper.Map<PhoneNumberTypeDto>(entity)
            };
            return vm;

        }
    }
}
