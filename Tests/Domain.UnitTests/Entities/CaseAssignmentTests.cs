using CaseCore.Domain.Entities;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using CaseCore.Domain.UnitTests.Common;
using System;
using Xunit;

namespace CaseCore.Domain.UnitTests.Entities
{
    public class CaseAssignmentTests : EntityTestBase
    {
        [Fact]
        public void Given_Valid_Values_CaseAssignment_Is_Valid()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            CaseAssignmentType newAssignmentType = _factory.CreateCaseAssignmentType();
            string newUser = "tesetUser";
            DateTime newAssignmentDate = new DateTime(2021, 8, 9);
            string newRemarks = "test remarks";

            // Act
            CaseAssignment newAssignment = new CaseAssignment(newCase, newAssignmentType, newUser, newAssignmentDate, newRemarks);

            // Assert
            Assert.Equal(newCase, newAssignment.Case);
            Assert.Equal(newAssignmentType, newAssignment.CaseAssignmentType);
            Assert.Equal(newUser, newAssignment.AssignedToName);
            Assert.Equal(newAssignmentDate, newAssignment.AssignmentDate);
            Assert.Equal(newRemarks, newAssignment.Remarks);
        }
        [Fact]
        public void Can_Update_Remarks()
        {
            // Arrange
            CaseAssignment newAssignment = _factory.CreateCaseAssignment();
            string newRemarks = "These are new remarks";

            // Act
            newAssignment.UpdateRemarks(newRemarks);

            // Assert
            Assert.Equal(newRemarks, newAssignment.Remarks);
        }
        [Theory]
        [InlineData("")]
        [InlineData("            ")]        
        public void Should_Throw_CaseAssignmentArgumentException_For_Invalid_Remarks(string value)
        {
            // Arrange
            CaseAssignment newAssignment = _factory.CreateCaseAssignment();

            // Act/Assert
            Assert.Throws<CaseAssignmentArgumentException>(() => newAssignment.UpdateRemarks(value));
        }
        [Fact]
        public void Should_Throw_CaseAssignmentArgumentException_For_Excessive_Remarks_Length()
        {
            // Arrange
            CaseAssignment newAssignment = _factory.CreateCaseAssignment();
            string newRemarks = new string('*', 1001);
            // Act/Assert
            Assert.Throws<CaseAssignmentArgumentException>(() => newAssignment.UpdateRemarks(newRemarks));
        }

    }
}
