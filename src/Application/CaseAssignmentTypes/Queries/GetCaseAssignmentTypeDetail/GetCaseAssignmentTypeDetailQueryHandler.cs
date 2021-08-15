using AutoMapper;
using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Domain.Types;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.CaseAssignmentTypes.Queries.GetCaseAssignmentTypeDetail
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests for details of a <see cref="Domain.Types.CaseAssignmentType"></see>
    /// </summary>
    public class GetCaseAssignmentTypeDetailQueryHandler : IRequestHandler<GetCaseAssignmentTypeDetailQuery, CaseAssignmentTypeDetailVm>
    {
        private readonly ICaseCoreDbContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        public GetCaseAssignmentTypeDetailQueryHandler(ICaseCoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request">A <see cref="GetCaseAssignmentTypeDetailQuery"/> object.</param>
        /// <param name="cancellationToken">A CancellationToken</param>
        /// <returns>A <see cref="CaseAssignmentTypeDetailVm"/> containing the Case Assignment Type Details.</returns>
        /// <exception cref="NotFoundException">Thrown when no Address Type with the provided Id was found.</exception>
        public async Task<CaseAssignmentTypeDetailVm> Handle(GetCaseAssignmentTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.CaseAssignmentTypes.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(CaseAssignmentType), request.Id);
            }
            var vm = new CaseAssignmentTypeDetailVm
            {
                CaseAssignmentType = _mapper.Map<CaseAssignmentTypeDto>(entity)
            };
            return vm;
        }
    }
}
