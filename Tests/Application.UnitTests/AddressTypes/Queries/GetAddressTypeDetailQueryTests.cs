using AutoMapper;
using CaseCore.Application.AddressTypes.Queries.GetAddressTypeDetail;
using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.UnitTests.Common;
using CaseCore.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.Application.UnitTests.AddressTypes.Queries
{
    [Collection("QueryCollection")]
    public class GetAddressTypeDetailQueryTests
    {
        private readonly CaseCoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAddressTypeDetailQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public async Task Handle_Get_AddressTypeDetail_With_Valid_Id_Returns_AddressType()
        {
            // Arrange
            var sut = new GetAddressTypeDetailQueryHandler(_context, _mapper);

            // Act
            var result = await sut.Handle(new GetAddressTypeDetailQuery { Id = 1 }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AddressTypeDetailVm>();
            result.AddressType.Id.ShouldBe(1);
            result.AddressType.Name.ShouldBe("Location of Incident");
            result.AddressType.Abbreviation.ShouldBe("LOI");
        }
        [Fact]
        public async Task Handle_Get_AddressTypeDetail_With_Invalid_Id_Throws_NotFoundException()
        {
            // Arrange
            var sut = new GetAddressTypeDetailQueryHandler(_context, _mapper);

            // Act/Assert
            await Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(new GetAddressTypeDetailQuery { Id = 100 }, CancellationToken.None));
        }
    }
}
