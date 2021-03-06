using AutoMapper;
using CaseCore.Application.CaseStatusTypes.Queries.GetCaseStatusTypeList;
using CaseCore.Application.UnitTests.Common;
using CaseCore.Persistence;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.Application.UnitTests.CaseStatusTypes.Queries
{
    [Collection("QueryCollection")]
    public class GetCaseStatusTypeListQueryTests
    {
        private readonly CaseCoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCaseStatusTypeListQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public async Task Handle_Get_CaseStatusTypeList_Returns_List()
        {
            // Arrange
            var sut = new GetCaseStatusTypeListQueryHandler(_context, _mapper);
            var command = new GetCaseStatusTypeListQuery { };

            // Act
            var result = await sut.Handle(command, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseStatusTypeListVm>();
            result.CaseStatusTypes.Count().ShouldBe(5);
        }
        [Fact]
        public async Task Handle_Get_CaseStatusTypeList_With_Paging_Correctly_Pages()
        {
            // Arrange
            var sut = new GetCaseStatusTypeListQueryHandler(_context, _mapper);
            var query = new GetCaseStatusTypeListQuery
            {
                PageSize = 1
            };
            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseStatusTypeListVm>();
            result.CaseStatusTypes.Count().ShouldBe(1);
            Assert.Equal(5, result.PagingInfo.TotalItems);
            Assert.Equal("Open", result.CaseStatusTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_CaseStatusTypeList_With_Paging_Returns_Second_Page()
        {
            // Arrange
            var sut = new GetCaseStatusTypeListQueryHandler(_context, _mapper);
            var query = new GetCaseStatusTypeListQuery
            {
                PageSize = 1,
                PageNumber = 2
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseStatusTypeListVm>();
            result.CaseStatusTypes.Count().ShouldBe(1);
            Assert.Equal(5, result.PagingInfo.TotalItems);
            Assert.Equal("InActive", result.CaseStatusTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_CaseStatusTypeList_Should_Default_Sort_By_Id_Ascending()
        {
            // Arrange
            var sut = new GetCaseStatusTypeListQueryHandler(_context, _mapper);
            var query = new GetCaseStatusTypeListQuery
            {
                SortOrder = ""
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseStatusTypeListVm>();
            result.CaseStatusTypes.Count().ShouldBe(5);
            Assert.Equal("", result.CurrentSort);
            Assert.Equal("id_desc", result.IdSort);
            Assert.Equal(5, result.PagingInfo.TotalItems);
            Assert.Equal("Open", result.CaseStatusTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_CaseStatusTypeList_Can_Sort_By_Id_Descending()
        {
            // Arrange
            var sut = new GetCaseStatusTypeListQueryHandler(_context, _mapper);
            var query = new GetCaseStatusTypeListQuery
            {
                SortOrder = "id_desc"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseStatusTypeListVm>();
            result.CaseStatusTypes.Count().ShouldBe(5);
            Assert.Equal("id_desc", result.CurrentSort);
            Assert.Equal("", result.IdSort);
            Assert.Equal(5, result.PagingInfo.TotalItems);
            Assert.Equal("Closed (Exception)", result.CaseStatusTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_CaseStatusTypeList_Can_Sort_By_Name_Descending()
        {
            // Arrange
            var sut = new GetCaseStatusTypeListQueryHandler(_context, _mapper);
            var query = new GetCaseStatusTypeListQuery
            {
                SortOrder = "caseStatusTypeName_desc"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseStatusTypeListVm>();
            result.CaseStatusTypes.Count().ShouldBe(5);
            Assert.Equal("caseStatusTypeName_desc", result.CurrentSort);
            Assert.Equal("caseStatusTypeName", result.NameSort);
            Assert.Equal(5, result.PagingInfo.TotalItems);
            Assert.Equal("Open", result.CaseStatusTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_CaseStatusTypeList_Can_Sort_By_Name_Ascending()
        {
            // Arrange
            var sut = new GetCaseStatusTypeListQueryHandler(_context, _mapper);
            var query = new GetCaseStatusTypeListQuery
            {
                SortOrder = "caseStatusTypeName"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseStatusTypeListVm>();
            result.CaseStatusTypes.Count().ShouldBe(5);
            Assert.Equal("caseStatusTypeName", result.CurrentSort);
            Assert.Equal("caseStatusTypeName_desc", result.NameSort);
            Assert.Equal(5, result.PagingInfo.TotalItems);
            Assert.Equal("Closed (Admin)", result.CaseStatusTypes.First().Name);
        }
    }
}
