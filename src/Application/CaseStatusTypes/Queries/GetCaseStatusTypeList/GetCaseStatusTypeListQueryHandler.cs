using AutoMapper;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.CaseStatusTypes.Queries.GetCaseStatusTypeList
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests for a list of a <see cref="Domain.Types.CaseStatusType"></see>
    /// </summary>
    public class GetCaseStatusTypeListQueryHandler : IRequestHandler<GetCaseStatusTypeListQuery, CaseStatusTypeListVm>
    {
        private readonly ICaseCoreDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        public GetCaseStatusTypeListQueryHandler(ICaseCoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request">A <see cref="GetCaseStatusTypeListQuery"/> object.</param>
        /// <param name="cancellationToken">A CancellationToken.</param>
        /// <returns>A <see cref="CaseStatusTypeListVm"/> containing a list of Fund Bank Types.</returns>    
        public async Task<CaseStatusTypeListVm> Handle(GetCaseStatusTypeListQuery request, CancellationToken cancellationToken)
        {
            CaseStatusTypeListVm vm = new CaseStatusTypeListVm
            {
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = request.PageSize,
                    CurrentPage = request.PageNumber
                }
            };

            vm.CaseStatusTypes = await _context.CaseStatusTypes
                .Select(x => new CaseStatusTypeDto { Id = x.Id, Name = x.Name })
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            vm.PagingInfo.TotalItems = await _context.CaseStatusTypes.CountAsync();
            vm.CurrentSort = request.SortOrder;
            vm.NameSort = request.SortOrder == "caseStatusTypeName" ? "caseStatusTypeName_desc" : "caseStatusTypeName";
            vm.IdSort = String.IsNullOrEmpty(request.SortOrder) ? "id_desc" : "";
            vm.CaseStatusTypes = request.SortOrder switch
            {
                "caseStatusTypeName" => vm.CaseStatusTypes.OrderBy(x => x.Name).ToList(),
                "caseStatusTypeName_desc" => vm.CaseStatusTypes.OrderByDescending(x => x.Name).ToList(),
                "id_desc" => vm.CaseStatusTypes.OrderByDescending(x => x.Id).ToList(),
                _ => vm.CaseStatusTypes.OrderBy(x => x.Id).ToList(),
            };
            return vm;
        }
    }
}
