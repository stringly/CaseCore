using AutoMapper;
using CaseCore.Application.PhoneNumberTypes.Queries.GetPhoneNumberTypeList;
using CaseCore.Application.UnitTests.Common;
using CaseCore.Persistence;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.Application.UnitTests.PhoneNumberTypes.Queries
{
    [Collection("QueryCollection")]
    public class GetPhoneNumberTypeListQueryTests
    {
        private readonly CaseCoreDbContext _context;
        private readonly IMapper _mapper;

        public GetPhoneNumberTypeListQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public async Task Handle_Get_PhoneNumberTypeList_Returns_List()
        {
            // Arrange
            var sut = new GetPhoneNumberTypeListQueryHandler(_context, _mapper);
            var command = new GetPhoneNumberTypeListQuery { };

            // Act
            var result = await sut.Handle(command, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PhoneNumberTypeListVm>();
            result.PhoneNumberTypes.Count().ShouldBe(4);
        }
        [Fact]
        public async Task Handle_Get_PhoneNumberTypeList_With_Paging_Correctly_Pages()
        {
            // Arrange
            var sut = new GetPhoneNumberTypeListQueryHandler(_context, _mapper);
            var query = new GetPhoneNumberTypeListQuery
            {
                PageSize = 1
            };
            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PhoneNumberTypeListVm>();
            result.PhoneNumberTypes.Count().ShouldBe(1);
            Assert.Equal(4, result.PagingInfo.TotalItems);
            Assert.Equal("Home", result.PhoneNumberTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_PhoneNumberTypeList_With_Paging_Returns_Second_Page()
        {
            // Arrange
            var sut = new GetPhoneNumberTypeListQueryHandler(_context, _mapper);
            var query = new GetPhoneNumberTypeListQuery
            {
                PageSize = 1,
                PageNumber = 2
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PhoneNumberTypeListVm>();
            result.PhoneNumberTypes.Count().ShouldBe(1);
            Assert.Equal(4, result.PagingInfo.TotalItems);
            Assert.Equal("Work", result.PhoneNumberTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_PhoneNumberTypeList_Should_Default_Sort_By_Id_Ascending()
        {
            // Arrange
            var sut = new GetPhoneNumberTypeListQueryHandler(_context, _mapper);
            var query = new GetPhoneNumberTypeListQuery
            {
                SortOrder = ""
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PhoneNumberTypeListVm>();
            result.PhoneNumberTypes.Count().ShouldBe(4);
            Assert.Equal("", result.CurrentSort);
            Assert.Equal("id_desc", result.IdSort);
            Assert.Equal(4, result.PagingInfo.TotalItems);
            Assert.Equal("Home", result.PhoneNumberTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_PhoneNumberTypeList_Can_Sort_By_Id_Descending()
        {
            // Arrange
            var sut = new GetPhoneNumberTypeListQueryHandler(_context, _mapper);
            var query = new GetPhoneNumberTypeListQuery
            {
                SortOrder = "id_desc"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PhoneNumberTypeListVm>();
            result.PhoneNumberTypes.Count().ShouldBe(4);
            Assert.Equal("id_desc", result.CurrentSort);
            Assert.Equal("", result.IdSort);
            Assert.Equal(4, result.PagingInfo.TotalItems);
            Assert.Equal("Fax", result.PhoneNumberTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_PhoneNumberTypeList_Can_Sort_By_Name_Descending()
        {
            // Arrange
            var sut = new GetPhoneNumberTypeListQueryHandler(_context, _mapper);
            var query = new GetPhoneNumberTypeListQuery
            {
                SortOrder = "phoneNumberTypeName_desc"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PhoneNumberTypeListVm>();
            result.PhoneNumberTypes.Count().ShouldBe(4);
            Assert.Equal("phoneNumberTypeName_desc", result.CurrentSort);
            Assert.Equal("phoneNumberTypeName", result.NameSort);
            Assert.Equal(4, result.PagingInfo.TotalItems);
            Assert.Equal("Work", result.PhoneNumberTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_PhoneNumberTypeList_Can_Sort_By_Name_Ascending()
        {
            // Arrange
            var sut = new GetPhoneNumberTypeListQueryHandler(_context, _mapper);
            var query = new GetPhoneNumberTypeListQuery
            {
                SortOrder = "phoneNumberTypeName"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PhoneNumberTypeListVm>();
            result.PhoneNumberTypes.Count().ShouldBe(4);
            Assert.Equal("phoneNumberTypeName", result.CurrentSort);
            Assert.Equal("phoneNumberTypeName_desc", result.NameSort);
            Assert.Equal(4, result.PagingInfo.TotalItems);
            Assert.Equal("Fax", result.PhoneNumberTypes.First().Name);
        }
    }
}
