using AutoMapper;
using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Domain.Types;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.CaseStatusTypes.Queries.GetCaseStatusTypeDetail
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests for details of a <see cref="Domain.Types.CaseStatusType"></see>
    /// </summary>
    public class GetCaseStatusTypeDetailQueryHandler : IRequestHandler<GetCaseStatusTypeDetailQuery, CaseStatusTypeDetailVm>
    {
        private readonly ICaseCoreDbContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        public GetCaseStatusTypeDetailQueryHandler(ICaseCoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request">A <see cref="GetCaseStatusTypeDetailQuery"/> object.</param>
        /// <param name="cancellationToken">A CancellationToken</param>
        /// <returns>A <see cref="CaseStatusTypeDetailVm"/> containing the Case Status Type Details.</returns>
        /// <exception cref="NotFoundException">Thrown when no Case Status Type with the provided Id was found.</exception>
        public async Task<CaseStatusTypeDetailVm> Handle(GetCaseStatusTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.CaseStatusTypes.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(CaseStatusType), request.Id);
            }
            var vm = new CaseStatusTypeDetailVm
            {
                CaseStatusType = _mapper.Map<CaseStatusTypeDto>(entity)
            };
            return vm;
        }
    }
}
