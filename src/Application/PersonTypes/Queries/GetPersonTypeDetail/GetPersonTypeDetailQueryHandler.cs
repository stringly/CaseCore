using AutoMapper;
using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Domain.Types;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.PersonTypes.Queries.GetPersonTypeDetail
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests for details of a <see cref="Domain.Types.PersonType"></see>
    /// </summary>
    public class GetPersonTypeDetailQueryHandler : IRequestHandler<GetPersonTypeDetailQuery, PersonTypeDetailVm>
    {
        private readonly ICaseCoreDbContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        public GetPersonTypeDetailQueryHandler(ICaseCoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request">A <see cref="GetPersonTypeDetailQuery"/> object.</param>
        /// <param name="cancellationToken">A CancellationToken</param>
        /// <returns>A <see cref="PersonTypeDetailVm"/> containing the Person Type Details.</returns>
        /// <exception cref="NotFoundException">Thrown when no Person Type with the provided Id was found.</exception>
        public async Task<PersonTypeDetailVm> Handle(GetPersonTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.PersonTypes.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(CaseStatusType), request.Id);
            }
            var vm = new PersonTypeDetailVm
            {
                PersonType = _mapper.Map<PersonTypeDto>(entity)
            };
            return vm;
        }
    }
}
