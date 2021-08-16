using AutoMapper;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseCore.Application.PhoneNumberTypes.Queries.GetPhoneNumberTypeList
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests for a list of a <see cref="Domain.Types.PhoneNumberType"></see>
    /// </summary>
    public class GetPhoneNumberTypeListQueryHandler : IRequestHandler<GetPhoneNumberTypeListQuery, PhoneNumberTypeListVm>
    {
        private readonly ICaseCoreDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="ICaseCoreDbContext"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        public GetPhoneNumberTypeListQueryHandler(ICaseCoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request">A <see cref="GetPhoneNumberTypeListQuery"/> object.</param>
        /// <param name="cancellationToken">A CancellationToken.</param>
        /// <returns>A <see cref="PhoneNumberTypeListVm"/> containing a list of Phone Number Types.</returns>    
        public async Task<PhoneNumberTypeListVm> Handle(GetPhoneNumberTypeListQuery request, CancellationToken cancellationToken)
        {
            PhoneNumberTypeListVm vm = new PhoneNumberTypeListVm
            {
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = request.PageSize,
                    CurrentPage = request.PageNumber
                }
            };

            vm.PhoneNumberTypes = await _context.PhoneNumberTypes
                .Select(x => new PhoneNumberTypeDto { Id = x.Id, Name = x.Name, Abbreviation = x.Abbreviation })
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            vm.PagingInfo.TotalItems = await _context.PhoneNumberTypes.CountAsync();
            vm.CurrentSort = request.SortOrder;
            vm.NameSort = request.SortOrder == "phoneNumberTypeName" ? "phoneNumberTypeName_desc" : "phoneNumberTypeName";
            vm.IdSort = String.IsNullOrEmpty(request.SortOrder) ? "id_desc" : "";
            vm.PhoneNumberTypes = request.SortOrder switch
            {
                "phoneNumberTypeName" => vm.PhoneNumberTypes.OrderBy(x => x.Name).ToList(),
                "phoneNumberTypeName_desc" => vm.PhoneNumberTypes.OrderByDescending(x => x.Name).ToList(),
                "id_desc" => vm.PhoneNumberTypes.OrderByDescending(x => x.Id).ToList(),
                _ => vm.PhoneNumberTypes.OrderBy(x => x.Id).ToList(),
            };
            return vm;
        }
    }
}
