using AutoMapper;
using CaseCore.Application.AddressTypes.Queries.GetAddressTypeList;
using CaseCore.Application.UnitTests.Common;
using CaseCore.Persistence;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.Application.UnitTests.AddressTypes.Queries
{
    [Collection("QueryCollection")]
    public class GetAddressTypeListQueryTests
    {
        private readonly CaseCoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAddressTypeListQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_Get_AddressTypeList_Returns_List()
        {
            // Arrange
            var sut = new GetAddressTypeListQueryHandler(_context, _mapper);
            var command = new GetAddressTypeListQuery { };

            // Act
            var result = await sut.Handle(command, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AddressTypeListVm>();
            result.AddressTypes.Count().ShouldBe(5);
        }
        [Fact]
        public async Task Handle_Get_AddressTypeList_With_Paging_Correctly_Pages()
        {
            // Arrange
            var sut = new GetAddressTypeListQueryHandler(_context, _mapper);
            var query = new GetAddressTypeListQuery
            {
                PageSize = 1
            };
            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AddressTypeListVm>();
            result.AddressTypes.Count().ShouldBe(1);
            Assert.Equal(5, result.PagingInfo.TotalItems);
            Assert.Equal("Location of Incident", result.AddressTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_AddressTypeList_With_Paging_Returns_Second_Page()
        {
            // Arrange
            var sut = new GetAddressTypeListQueryHandler(_context, _mapper);
            var query = new GetAddressTypeListQuery
            {
                PageSize = 1,
                PageNumber = 2
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AddressTypeListVm>();
            result.AddressTypes.Count().ShouldBe(1);
            Assert.Equal(5, result.PagingInfo.TotalItems);
            Assert.Equal("Home Address", result.AddressTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_AddressTypeList_Should_Default_Sort_By_Id_Ascending()
        {
            // Arrange
            var sut = new GetAddressTypeListQueryHandler(_context, _mapper);
            var query = new GetAddressTypeListQuery
            {
                SortOrder = ""
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AddressTypeListVm>();
            result.AddressTypes.Count().ShouldBe(5);
            Assert.Equal("", result.CurrentSort);
            Assert.Equal("id_desc", result.IdSort);
            Assert.Equal(5, result.PagingInfo.TotalItems);
            Assert.Equal("Location of Incident", result.AddressTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_AddressTypeList_Can_Sort_By_Id_Descending()
        {
            // Arrange
            var sut = new GetAddressTypeListQueryHandler(_context, _mapper);
            var query = new GetAddressTypeListQuery
            {
                SortOrder = "id_desc"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AddressTypeListVm>();
            result.AddressTypes.Count().ShouldBe(5);
            Assert.Equal("id_desc", result.CurrentSort);
            Assert.Equal("", result.IdSort);
            Assert.Equal(5, result.PagingInfo.TotalItems);
            Assert.Equal("Location of Apprehension", result.AddressTypes.First().Name);

        }
        [Fact]
        public async Task Handle_Get_AddressTypeList_Can_Sort_By_Name_Descending()
        {
            // Arrange
            var sut = new GetAddressTypeListQueryHandler(_context, _mapper);
            var query = new GetAddressTypeListQuery
            {
                SortOrder = "addressTypeName_desc"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AddressTypeListVm>();
            result.AddressTypes.Count().ShouldBe(5);
            Assert.Equal("addressTypeName_desc", result.CurrentSort);
            Assert.Equal("addressTypeName", result.NameSort);
            Assert.Equal(5, result.PagingInfo.TotalItems);
            Assert.Equal("Work Address", result.AddressTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_AddressTypeList_Can_Sort_By_Name_Ascending()
        {
            // Arrange
            var sut = new GetAddressTypeListQueryHandler(_context, _mapper);
            var query = new GetAddressTypeListQuery
            {
                SortOrder = "addressTypeName"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AddressTypeListVm>();
            result.AddressTypes.Count().ShouldBe(5);
            Assert.Equal("addressTypeName", result.CurrentSort);
            Assert.Equal(5, result.PagingInfo.TotalItems);
            Assert.Equal("Home Address", result.AddressTypes.First().Name);
        }
    }
}
