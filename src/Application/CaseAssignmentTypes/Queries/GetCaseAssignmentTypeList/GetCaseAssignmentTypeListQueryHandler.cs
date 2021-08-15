using AutoMapper;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.CaseAssignmentTypes.Queries.GetCaseAssignmentTypeList
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests for a list of a <see cref="Domain.Types.CaseAssignmentType"></see>
    /// </summary>
    public class GetCaseAssignmentTypeListQueryHandler : IRequestHandler<GetCaseAssignmentTypeListQuery, CaseAssignmentTypeListVm>
    {
        private readonly ICaseCoreDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        public GetCaseAssignmentTypeListQueryHandler(ICaseCoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request">A <see cref="GetCaseAssignmentTypeListQuery"/> object.</param>
        /// <param name="cancellationToken">A CancellationToken.</param>
        /// <returns>A <see cref="CaseAssignmentTypeListVm"/> containing a list of Fund Bank Types.</returns>    
        public async Task<CaseAssignmentTypeListVm> Handle(GetCaseAssignmentTypeListQuery request, CancellationToken cancellationToken)
        {
            CaseAssignmentTypeListVm vm = new CaseAssignmentTypeListVm
            {
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = request.PageSize,
                    CurrentPage = request.PageNumber
                }
            };

            vm.CaseAssignmentTypes = await _context.CaseAssignmentTypes
                .Select(x => new CaseAssignmentTypeDto { Id = x.Id, Name = x.Name })
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            vm.PagingInfo.TotalItems = await _context.CaseAssignmentTypes.CountAsync();
            vm.CurrentSort = request.SortOrder;
            vm.NameSort = request.SortOrder == "caseAssignmentTypeName" ? "caseAssignmentTypeName_desc" : "caseAssignmentTypeName";
            vm.IdSort = String.IsNullOrEmpty(request.SortOrder) ? "id_desc" : "";
            vm.CaseAssignmentTypes = request.SortOrder switch
            {
                "caseAssignmentTypeName" => vm.CaseAssignmentTypes.OrderBy(x => x.Name).ToList(),
                "caseAssignmentTypeName_desc" => vm.CaseAssignmentTypes.OrderByDescending(x => x.Name).ToList(),
                "id_desc" => vm.CaseAssignmentTypes.OrderByDescending(x => x.Id).ToList(),
                _ => vm.CaseAssignmentTypes.OrderBy(x => x.Id).ToList(),
            };
            return vm;
        }
    }
}
