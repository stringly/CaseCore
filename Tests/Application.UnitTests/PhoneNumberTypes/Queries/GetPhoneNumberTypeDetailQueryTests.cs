using AutoMapper;
using CaseCore.Application.Common.Exceptions;
using CaseCore.Application.PhoneNumberTypes.Queries.GetPhoneNumberTypeDetail;
using CaseCore.Application.UnitTests.Common;
using CaseCore.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.Application.UnitTests.PhoneNumberTypes.Queries
{
    [Collection("QueryCollection")]
    public class GetPhoneNumberTypeDetailQueryTests
    {
        private readonly CaseCoreDbContext _context;
        private readonly IMapper _mapper;

        public GetPhoneNumberTypeDetailQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public async Task Handle_Get_PhoneNumberTypeDetail_With_Valid_Id_Returns_PhoneNumberType()
        {
            // Arrange
            var sut = new GetPhoneNumberTypeDetailQueryHandler(_context, _mapper);

            // Act
            var result = await sut.Handle(new GetPhoneNumberTypeDetailQuery { Id = 1 }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PhoneNumberTypeDetailVm>();
            result.PhoneNumberType.Id.ShouldBe(1);
            result.PhoneNumberType.Name.ShouldBe("Home");
        }
        [Fact]
        public async Task Handle_Get_PersonTypeDetail_With_Invalid_Id_Throws_NotFoundException()
        {
            // Arrange
            var sut = new GetPhoneNumberTypeDetailQueryHandler(_context, _mapper);

            // Act/Assert
            await Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(new GetPhoneNumberTypeDetailQuery { Id = 100 }, CancellationToken.None));
        }
    }
}
