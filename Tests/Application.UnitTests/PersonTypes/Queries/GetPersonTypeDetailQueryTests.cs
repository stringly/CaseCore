using AutoMapper;
using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.PersonTypes.Queries.GetPersonTypeDetail;
using CaseCore.Application.UnitTests.Common;
using CaseCore.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.Application.UnitTests.PersonTypes.Queries
{
    [Collection("QueryCollection")]
    public class GetPersonTypeDetailQueryTests
    {
        private readonly CaseCoreDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonTypeDetailQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public async Task Handle_Get_PersonTypeDetail_With_Valid_Id_Returns_CaseStatusType()
        {
            // Arrange
            var sut = new GetPersonTypeDetailQueryHandler(_context, _mapper);

            // Act
            var result = await sut.Handle(new GetPersonTypeDetailQuery { Id = 1 }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PersonTypeDetailVm>();
            result.PersonType.Id.ShouldBe(1);
            result.PersonType.Name.ShouldBe("Victim");
        }
        [Fact]
        public async Task Handle_Get_PersonTypeDetail_With_Invalid_Id_Throws_NotFoundException()
        {
            // Arrange
            var sut = new GetPersonTypeDetailQueryHandler(_context, _mapper);

            // Act/Assert
            await Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(new GetPersonTypeDetailQuery { Id = 100 }, CancellationToken.None));
        }
    }
}
