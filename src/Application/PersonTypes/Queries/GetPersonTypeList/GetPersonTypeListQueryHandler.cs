using AutoMapper;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.PersonTypes.Queries.GetPersonTypeList
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests for a list of a <see cref="Domain.Types.PersonType"></see>
    /// </summary>
    public class GetPersonTypeListQueryHandler : IRequestHandler<GetPersonTypeListQuery, PersonTypeListVm>
    {
        private readonly ICaseCoreDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        public GetPersonTypeListQueryHandler(ICaseCoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request">A <see cref="GetPersonTypeListQuery"/> object.</param>
        /// <param name="cancellationToken">A CancellationToken.</param>
        /// <returns>A <see cref="PersonTypeListVm"/> containing a list of Fund Bank Types.</returns>    
        public async Task<PersonTypeListVm> Handle(GetPersonTypeListQuery request, CancellationToken cancellationToken)
        {
            PersonTypeListVm vm = new PersonTypeListVm
            {
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = request.PageSize,
                    CurrentPage = request.PageNumber
                }
            };

            vm.PersonTypes = await _context.PersonTypes
                .Select(x => new PersonTypeDto { Id = x.Id, Name = x.Name, Abbreviation = x.Abbreviation })
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            vm.PagingInfo.TotalItems = await _context.PersonTypes.CountAsync();
            vm.CurrentSort = request.SortOrder;
            vm.NameSort = request.SortOrder == "personTypeName" ? "personTypeName_desc" : "personTypeName";
            vm.IdSort = String.IsNullOrEmpty(request.SortOrder) ? "id_desc" : "";
            vm.PersonTypes = request.SortOrder switch
            {
                "personTypeName" => vm.PersonTypes.OrderBy(x => x.Name).ToList(),
                "personTypeName_desc" => vm.PersonTypes.OrderByDescending(x => x.Name).ToList(),
                "id_desc" => vm.PersonTypes.OrderByDescending(x => x.Id).ToList(),
                _ => vm.PersonTypes.OrderBy(x => x.Id).ToList(),
            };
            return vm;
        }
    }
}
