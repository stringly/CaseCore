using AutoMapper;
using CaseCore.Application.PersonTypes.Queries.GetPersonTypeList;
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

namespace CaseCore.Application.UnitTests.PersonTypes.Queries
{
    [Collection("QueryCollection")]
    public class GetPersonTypeListQueryTests
    {
        private readonly CaseCoreDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonTypeListQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public async Task Handle_Get_PersonTypeList_Returns_List()
        {
            // Arrange
            var sut = new GetPersonTypeListQueryHandler(_context, _mapper);
            var command = new GetPersonTypeListQuery { };

            // Act
            var result = await sut.Handle(command, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PersonTypeListVm>();
            result.PersonTypes.Count().ShouldBe(7);
        }
        [Fact]
        public async Task Handle_Get_PersonTypeList_With_Paging_Correctly_Pages()
        {
            // Arrange
            var sut = new GetPersonTypeListQueryHandler(_context, _mapper);
            var query = new GetPersonTypeListQuery
            {
                PageSize = 1
            };
            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PersonTypeListVm>();
            result.PersonTypes.Count().ShouldBe(1);
            Assert.Equal(7, result.PagingInfo.TotalItems);
            Assert.Equal("Victim", result.PersonTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_PersonTypeList_With_Paging_Returns_Second_Page()
        {
            // Arrange
            var sut = new GetPersonTypeListQueryHandler(_context, _mapper);
            var query = new GetPersonTypeListQuery
            {
                PageSize = 1,
                PageNumber = 2
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PersonTypeListVm>();
            result.PersonTypes.Count().ShouldBe(1);
            Assert.Equal(7, result.PagingInfo.TotalItems);
            Assert.Equal("Witness", result.PersonTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_PersonTypeList_Should_Default_Sort_By_Id_Ascending()
        {
            // Arrange
            var sut = new GetPersonTypeListQueryHandler(_context, _mapper);
            var query = new GetPersonTypeListQuery
            {
                SortOrder = ""
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PersonTypeListVm>();
            result.PersonTypes.Count().ShouldBe(7);
            Assert.Equal("", result.CurrentSort);
            Assert.Equal("id_desc", result.IdSort);
            Assert.Equal(7, result.PagingInfo.TotalItems);
            Assert.Equal("Victim", result.PersonTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_PersonTypeList_Can_Sort_By_Id_Descending()
        {
            // Arrange
            var sut = new GetPersonTypeListQueryHandler(_context, _mapper);
            var query = new GetPersonTypeListQuery
            {
                SortOrder = "id_desc"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PersonTypeListVm>();
            result.PersonTypes.Count().ShouldBe(7);
            Assert.Equal("id_desc", result.CurrentSort);
            Assert.Equal("", result.IdSort);
            Assert.Equal(7, result.PagingInfo.TotalItems);
            Assert.Equal("Other", result.PersonTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_PersonTypeList_Can_Sort_By_Name_Descending()
        {
            // Arrange
            var sut = new GetPersonTypeListQueryHandler(_context, _mapper);
            var query = new GetPersonTypeListQuery
            {
                SortOrder = "personTypeName_desc"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PersonTypeListVm>();
            result.PersonTypes.Count().ShouldBe(7);
            Assert.Equal("personTypeName_desc", result.CurrentSort);
            Assert.Equal("personTypeName", result.NameSort);
            Assert.Equal(7, result.PagingInfo.TotalItems);
            Assert.Equal("Witness", result.PersonTypes.First().Name);
        }
        [Fact]
        public async Task Handle_Get_PersonTypeList_Can_Sort_By_Name_Ascending()
        {
            // Arrange
            var sut = new GetPersonTypeListQueryHandler(_context, _mapper);
            var query = new GetPersonTypeListQuery
            {
                SortOrder = "personTypeName"
            };

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PersonTypeListVm>();
            result.PersonTypes.Count().ShouldBe(7);
            Assert.Equal("personTypeName", result.CurrentSort);
            Assert.Equal("personTypeName_desc", result.NameSort);
            Assert.Equal(7, result.PagingInfo.TotalItems);
            Assert.Equal("Arrestee", result.PersonTypes.First().Name);
        }
    }
}
