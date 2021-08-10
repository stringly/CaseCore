using CaseCore.Domain.Entities;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using CaseCore.Domain.UnitTests.Common;
using System;
using Xunit;

namespace CaseCore.Domain.UnitTests.Entities
{
    public class CaseStatusTests : EntityTestBase
    {
        [Fact]
        public void Given_Valid_Values_CaseStatus_Is_Valid()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            CaseStatusType newCaseStatusType = _factory.CreateCaseStatusType();
            DateTime newDate = new DateTime(2021, 8, 9);
            string newRemarks = "Test Remarks";

            // Act
            CaseStatus newStatus = new CaseStatus(newCase, newCaseStatusType, newDate, newRemarks);

            // Assert
            Assert.Equal(newCase, newStatus.Case);
            Assert.Equal(newCaseStatusType, newStatus.CaseStatusType);
            Assert.Equal(newDate, newStatus.StatusDate);
            Assert.Equal(newRemarks, newStatus.Remarks);
        }
        [Theory]
        [InlineData("")]
        [InlineData("            ")]
        public void Should_Throw_CaseStatusArgumentException_For_Invalid_Remarks(string value)
        {
            // Arrange
            CaseStatus newStatus = _factory.CreateCaseStatus();

            // Act/Assert
            Assert.Throws<CaseStatusArgumentException>(() => newStatus.UpdateRemarks(value));
        }
        [Fact]
        public void Should_Throw_CaseStatusArgumentException_For_Excessive_Remarks_Length()
        {
            // Arrange
            CaseStatus newStatus = _factory.CreateCaseStatus();
            string newRemarks = new string('*', 1001);
            // Act/Assert
            Assert.Throws<CaseStatusArgumentException>(() => newStatus.UpdateRemarks(newRemarks));
        }
    }
}
