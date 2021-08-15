using AutoMapper;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.AddressTypes.Queries.GetAddressTypeList
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests for a list of a <see cref="Domain.Types.AddressType"></see>
    /// </summary>
    public class GetAddressTypeListQueryHandler : IRequestHandler<GetAddressTypeListQuery, AddressTypeListVm>
    {
        private readonly ICaseCoreDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        public GetAddressTypeListQueryHandler(ICaseCoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request">A <see cref="GetAddressTypeListQuery"/> object.</param>
        /// <param name="cancellationToken">A CancellationToken.</param>
        /// <returns>A <see cref="AddressTypeListVm"/> containing a list of Fund Bank Types.</returns>    
        public async Task<AddressTypeListVm> Handle(GetAddressTypeListQuery request, CancellationToken cancellationToken)
        {
            AddressTypeListVm vm = new AddressTypeListVm
            {
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = request.PageSize,
                    CurrentPage = request.PageNumber
                }
            };

            vm.AddressTypes = await _context.AddressTypes                
                .Select(x => new AddressTypeDto { Id = x.Id, Name = x.Name, Abbreviation = x.Abbreviation })
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)                
                .ToListAsync();

            vm.PagingInfo.TotalItems = await _context.AddressTypes.CountAsync();
            vm.CurrentSort = request.SortOrder;
            vm.NameSort = request.SortOrder == "addressTypeName" ? "addressTypeName_desc" : "addressTypeName";
            vm.IdSort = String.IsNullOrEmpty(request.SortOrder) ? "id_desc" : "";
            vm.AddressTypes = request.SortOrder switch
            {
                "addressTypeName" => vm.AddressTypes.OrderBy(x => x.Name).ToList(),
                "addressTypeName_desc" => vm.AddressTypes.OrderByDescending(x => x.Name).ToList(),
                "id_desc" => vm.AddressTypes.OrderByDescending(x => x.Id).ToList(),
                _ => vm.AddressTypes.OrderBy(x => x.Id).ToList(),
            };
            return vm;
        }
    }
}
