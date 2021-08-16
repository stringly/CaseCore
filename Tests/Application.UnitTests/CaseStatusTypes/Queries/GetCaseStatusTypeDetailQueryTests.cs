using AutoMapper;
using CaseCore.Application.CaseStatusTypes.Queries.GetCaseStatusTypeDetail;
using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.UnitTests.Common;
using CaseCore.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.Application.UnitTests.CaseStatusTypes.Queries
{
    [Collection("QueryCollection")]
    public class GetCaseStatusTypeDetailQueryTests
    {
        private readonly CaseCoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCaseStatusTypeDetailQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public async Task Handle_Get_CaseStatusTypeDetail_With_Valid_Id_Returns_CaseStatusType()
        {
            // Arrange
            var sut = new GetCaseStatusTypeDetailQueryHandler(_context, _mapper);

            // Act
            var result = await sut.Handle(new GetCaseStatusTypeDetailQuery { Id = 1 }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CaseStatusTypeDetailVm>();
            result.CaseStatusType.Id.ShouldBe(1);
            result.CaseStatusType.Name.ShouldBe("Open");
        }
        [Fact]
        public async Task Handle_Get_CaseStatusTypeDetail_With_Invalid_Id_Throws_NotFoundException()
        {
            // Arrange
            var sut = new GetCaseStatusTypeDetailQueryHandler(_context, _mapper);

            // Act/Assert
            await Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(new GetCaseStatusTypeDetailQuery { Id = 100 }, CancellationToken.None));
        }
    }
}
