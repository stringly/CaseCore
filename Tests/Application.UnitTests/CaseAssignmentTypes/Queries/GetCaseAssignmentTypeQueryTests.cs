using AutoMapper;
using CaseCore.Application.CaseAssignmentTypes.Queries.GetCaseAssignmentTypeList;
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

namespace CaseCore.Application.UnitTests.CaseAssignmentTypes.Queries
{
    [Collection("QueryCollection")]
    public class GetCaseAssignmentTypeQueryTests
    {
        private readonly CaseCoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCaseAssignmentTypeQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public async Task Handle_Get_CaseAssignmentTypeList_Returns_List()
        {
            // Arrange
            var sut = new GetCaseAssignmentTypeListQueryHandler(_context, _mapper);
            var command = new GetCaseAssignmentTypeListQuery { };

            // Act
            var result = await sut.Handle(command, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseAssignmentTypeListVm>();
            result.CaseAssignmentTypes.Count().ShouldBe(2);
        }
        [Fact]
        public async Task Handle_Get_CaseAssignmentTypeList_With_Paging_Correctly_Pages()
        {
            // Arrange
            var sut = new GetCaseAssignmentTypeListQueryHandler(_context, _mapper);
            var query = new GetCaseAssignmentTypeListQuery
            {
                PageSize = 1
            };
            
            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseAssignmentTypeListVm>();
            result.CaseAssignmentTypes.Count().ShouldBe(1);
            Assert.Equal(2, result.PagingInfo.TotalItems);
            Assert.Equal("Initial", result.CaseAssignmentTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_CaseAssignmentTypeList_With_Paging__Returns_Second_Page()
        {
            // Arrange
            var sut = new GetCaseAssignmentTypeListQueryHandler(_context, _mapper);
            var query = new GetCaseAssignmentTypeListQuery
            {
                PageSize = 1,
                PageNumber = 2
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseAssignmentTypeListVm>();
            result.CaseAssignmentTypes.Count().ShouldBe(1);
            Assert.Equal(2, result.PagingInfo.TotalItems);
            Assert.Equal("Reassigned", result.CaseAssignmentTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_CaseAssignmentTypeList_Should_Default_Sort_By_Id_Ascending()
        {
            // Arrange
            var sut = new GetCaseAssignmentTypeListQueryHandler(_context, _mapper);
            var query = new GetCaseAssignmentTypeListQuery
            {
                SortOrder = ""
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseAssignmentTypeListVm>();
            result.CaseAssignmentTypes.Count().ShouldBe(2);
            Assert.Equal("", result.CurrentSort);
            Assert.Equal("id_desc", result.IdSort);
            Assert.Equal(2, result.PagingInfo.TotalItems);
            Assert.Equal("Initial", result.CaseAssignmentTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_CaseAssignmentTypeList_Can_Sort_By_Id_Descending()
        {
            // Arrange
            var sut = new GetCaseAssignmentTypeListQueryHandler(_context, _mapper);
            var query = new GetCaseAssignmentTypeListQuery
            {
                SortOrder = "id_desc"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseAssignmentTypeListVm>();
            result.CaseAssignmentTypes.Count().ShouldBe(2);
            Assert.Equal("id_desc", result.CurrentSort);
            Assert.Equal("", result.IdSort);
            Assert.Equal(2, result.PagingInfo.TotalItems);
            Assert.Equal("Reassigned", result.CaseAssignmentTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_CaseAssignmentTypeList_Can_Sort_By_Name_Descending()
        {
            // Arrange
            var sut = new GetCaseAssignmentTypeListQueryHandler(_context, _mapper);
            var query = new GetCaseAssignmentTypeListQuery
            {
                SortOrder = "caseAssignmentTypeName_desc"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseAssignmentTypeListVm>();
            result.CaseAssignmentTypes.Count().ShouldBe(2);
            Assert.Equal("caseAssignmentTypeName_desc", result.CurrentSort);
            Assert.Equal("caseAssignmentTypeName", result.NameSort);
            Assert.Equal(2, result.PagingInfo.TotalItems);
            Assert.Equal("Reassigned", result.CaseAssignmentTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_CaseAssignmentTypeList_Can_Sort_By_Name_Ascending()
        {
            // Arrange
            var sut = new GetCaseAssignmentTypeListQueryHandler(_context, _mapper);
            var query = new GetCaseAssignmentTypeListQuery
            {
                SortOrder = "caseAssignmentTypeName"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseAssignmentTypeListVm>();
            result.CaseAssignmentTypes.Count().ShouldBe(2);
            Assert.Equal("caseAssignmentTypeName", result.CurrentSort);
            Assert.Equal("caseAssignmentTypeName_desc", result.NameSort);
            Assert.Equal(2, result.PagingInfo.TotalItems);
            Assert.Equal("Initial", result.CaseAssignmentTypes.First().Name);
        }
    }
}
