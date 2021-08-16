using AutoMapper;
using CaseCore.Application.CaseAssignmentTypes.Queries.GetCaseAssignmentTypeDetail;
using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.UnitTests.Common;
using CaseCore.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.Application.UnitTests.CaseAssignmentTypes.Queries
{
    [Collection("QueryCollection")]
    public class GetCaseAssignmentTypeDetailQueryTests
    {
        private readonly CaseCoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCaseAssignmentTypeDetailQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public async Task Handle_Get_AddressTypeDetail_With_Valid_Id_Returns_AddressType()
        {
            // Arrange
            var sut = new GetCaseAssignmentTypeDetailQueryHandler(_context, _mapper);

            // Act
            var result = await sut.Handle(new GetCaseAssignmentTypeDetailQuery { Id = 1 }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseAssignmentTypeDetailVm>();
            result.CaseAssignmentType.Id.ShouldBe(1);
            result.CaseAssignmentType.Name.ShouldBe("Initial");            
        }
        [Fact]
        public async Task Handle_Get_AddressTypeDetail_With_Invalid_Id_Throws_NotFoundException()
        {
            // Arrange
            var sut = new GetCaseAssignmentTypeDetailQueryHandler(_context, _mapper);

            // Act/Assert
            await Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(new GetCaseAssignmentTypeDetailQuery { Id = 100 }, CancellationToken.None));
        }
    }
}
