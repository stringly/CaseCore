using CaseCore.Domain.Entities;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using CaseCore.Domain.UnitTests.Common;
using System;
using System.Linq;
using Xunit;

namespace CaseCore.Domain.UnitTests.Entities
{
    public class CaseTests : EntityTestBase
    {
        // TODO: Add Case Entity Tests.
        [Fact]
        public void Given_Valid_Values_Case_Is_Valid()
        {
            // Arrange/Act
            Case newCase = _factory.CreateCase();

            // Assert
            Assert.Equal("PP12345600001111", newCase.CaseNumber);
            Assert.Single(newCase.Addresses);
            Assert.Equal(new DateTime(2020, 1, 1), newCase.OccurredOnExactDate);
            Assert.Equal(new DateTime(2020, 1, 2), newCase.ReportedOnDate);
        }
        [Fact]
        public void Can_Update_CaseNumber()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            string newCaseNumber = "11-222-3333";

            // Act
            newCase.UpdateCaseNumber(newCaseNumber);

            // Assert
            Assert.Equal(newCaseNumber, newCase.CaseNumber);
        }
        [Fact]
        public void Can_Update_OccurredOnExactDate()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            DateTime newOccurredOnExactDate = new DateTime(2019, 12, 31);

            // Act
            newCase.UpdateOccurredOnExactDate(newOccurredOnExactDate);

            // Assert
            Assert.Equal(newOccurredOnExactDate, newCase.OccurredOnExactDate);
        }
        [Fact]
        public void Can_Update_OccurredBetweenStartDate()
        {
            // Arrange
            Case newCase = _factory.CreateCase(2);
            DateTime newOccurredBetweenStartDate = new DateTime(2019, 12, 29);

            // Act
            newCase.UpdateOccurredBetweenDates(newOccurredBetweenStartDate);

            // Assert
            Assert.Equal(newOccurredBetweenStartDate, newCase.OccurredBetweenStartDate);
            Assert.Equal(new DateTime(2019, 12, 31), newCase.OccurredBetweenEndDate);
        }
        [Fact]
        public void Can_Update_OccurredBetweenEndDate()
        {
            // Arrange
            Case newCase = _factory.CreateCase(2);
            DateTime newOccurredBetweenEndDate = new DateTime(2020, 1, 1);

            // Act
            newCase.UpdateOccurredBetweenDates(null, newOccurredBetweenEndDate);

            // Assert
            Assert.Equal(newOccurredBetweenEndDate, newCase.OccurredBetweenEndDate);
            Assert.Equal(new DateTime(2019, 12, 30), newCase.OccurredBetweenStartDate);
        }
        [Fact]
        public void Can_Update_ReportedOnDate()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            DateTime newReportedOnDate = new DateTime(2020, 1, 3);

            // Act
            newCase.UpdateReportedOnDate(newReportedOnDate);

            // Assert
            Assert.Equal(newReportedOnDate, newCase.ReportedOnDate);
        }
        [Fact]
        public void Can_Add_Address()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            Address newAddress = new Address(_factory.CreateAddressType(), "999 1st St.", "", "Gotham", "NY", "99999");
            int initialAddressCount = newCase.Addresses.Count();

            // Act
            newCase.AddAddress(newAddress);

            // Assert
            Assert.Equal(1, initialAddressCount);
            Assert.Equal(2, newCase.Addresses.Count());
        }
        [Fact]
        public void Can_Remove_Address()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            Address newAddress = new Address(_factory.CreateAddressType(), "999 1st St.", "", "Gotham", "NY", "99999");
            newCase.AddAddress(newAddress);
            int initialAddressCount = newCase.Addresses.Count();

            // Act
            newCase.RemoveAddress(newAddress);

            // Assert
            Assert.Equal(2, initialAddressCount);
            Assert.Single(newCase.Addresses);
        }
        [Fact]
        public void Can_Add_Person()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            Person newPerson = _factory.CreatePerson();
            int initialPersonCount = newCase.Persons.Count();

            // Act
            newCase.AddPerson(newPerson);

            // Assert
            Assert.Equal(0, initialPersonCount);
            Assert.Single(newCase.Persons);
        }
        [Fact]
        public void Can_Remove_Person()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            Person newPerson = _factory.CreatePerson();
            newCase.AddPerson(newPerson);
            int initialPersonCount = newCase.Persons.Count();

            // Act
            newCase.RemovePerson(newPerson);

            // Assert
            Assert.Equal(1, initialPersonCount);
            Assert.Empty(newCase.Persons);
        }
        [Fact]
        public void Can_Add_CaseStatusEntry()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            DateTime newCaseStatusDate = new DateTime(2021, 8, 9);
            string newRemarks = "These are test remarks.";
            
            // Act
            newCase.UpdateCaseStatus(_factory.CreateCaseStatusType(), newCaseStatusDate, newRemarks);

            // Assert
            Assert.Single(newCase.CaseStatuses);
            Assert.Equal("Test", newCase.CurrentStatus.CaseStatusType.Name);
            Assert.Equal(newRemarks, newCase.CurrentStatus.Remarks);
            Assert.Equal(newCaseStatusDate, newCase.CurrentStatus.StatusDate);

        }
        [Fact]
        public void CurrentStatus_Will_Retrieve_Latest_Status()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            DateTime earlierDate = new DateTime(2021, 8, 1);
            DateTime laterDate = new DateTime(2021, 8, 9);
            newCase.UpdateCaseStatus(_factory.CreateCaseStatusType(), earlierDate, "Earlier entry");
            newCase.UpdateCaseStatus(_factory.CreateCaseStatusType(), laterDate, "Later entry");
            int statusCount = newCase.CaseStatuses.Count();

            // Act/Assert
            Assert.Equal("Later entry", newCase.CurrentStatus.Remarks);
            Assert.Equal(2, statusCount);
            
        }
        [Fact]
        public void Can_Add_CaseAssignment()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            string newAssignedToUserName = "testuser";
            DateTime newCaseAssignmentDate = new DateTime(2021, 8, 9);
            string newRemarks = "These are test remarks.";

            // Act
            newCase.UpdateCaseAssignment(_factory.CreateCaseAssignmentType(), newAssignedToUserName, newCaseAssignmentDate, newRemarks);

            // Assert
            Assert.Single(newCase.CaseAssignments);
            Assert.Equal(newAssignedToUserName, newCase.CurrentAssignment.AssignedToName);
            Assert.Equal(newCaseAssignmentDate, newCase.CurrentAssignment.AssignmentDate);
            Assert.Equal(newRemarks, newCase.CurrentAssignment.Remarks);
        }
        [Fact]
        public void CurrentAssignment_Will_Retrieve_Latest_Assignment()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            DateTime earlierDate = new DateTime(2021, 8, 1);
            DateTime laterDate = new DateTime(2021, 8, 9);
            string earlierUser = "earlyUser";
            string laterUser = "laterUser";
            string earlierRemarks = "Earlier entry";
            string laterRemarks = "Later entry";

            newCase.UpdateCaseAssignment(_factory.CreateCaseAssignmentType(), earlierUser, earlierDate, earlierRemarks);
            newCase.UpdateCaseAssignment(_factory.CreateCaseAssignmentType(), laterUser, laterDate, laterRemarks);

            // Assert
            Assert.Equal(2, newCase.CaseAssignments.Count());
            Assert.Equal(laterUser, newCase.CurrentAssignment.AssignedToName);
            Assert.Equal(laterDate, newCase.CurrentAssignment.AssignmentDate);
        }
        [Fact]
        public void Can_Add_CaseOffense()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            OffenseType offenseType = _factory.CreateOffenseType();

            // Act
            newCase.AddOffense(offenseType);

            // Assert
            Assert.Single(newCase.CaseOffenses);
        }
        [Fact]
        public void Can_Remove_CaseOffenses()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            OffenseType offenseType = _factory.CreateOffenseType();
            newCase.AddOffense(offenseType);
            int initialOffenseCount = newCase.CaseOffenses.Count();

            // Act
            newCase.RemoveOffense(offenseType);

            // Assert
            Assert.Equal(1, initialOffenseCount);
            Assert.Empty(newCase.CaseOffenses);
        }
        [Theory]
        [InlineData("")]
        [InlineData("            ")]
        public void Should_Throw_CaseArgumentException_For_Invalid_CaseNumber(string value)
        {
            // Arrange
            Case newCase = _factory.CreateCase();

            // Act/Assert
            Assert.Throws<CaseArgumentException>(() => newCase.UpdateCaseNumber(value));
        }
        [Fact]
        public void Should_Throw_CaseArgumentException_When_Removing_Address_Not_In_Collection()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            Address newAddress = new Address(_factory.CreateAddressType(), "888 8th St.","","Mainville","MD","11122");

            // Act/Assert
            Assert.Throws<CaseArgumentException>(() => newCase.RemoveAddress(newAddress));
        }
        [Fact]
        public void Should_Throw_CaseArgumentException_When_Removing_Person_Not_In_Collection()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            Person newPerson = _factory.CreatePerson();
            newCase.AddPerson(newPerson);
            Person anotherPerson = new Person(_factory.CreatePersonType(), "Mr", "John", "NMN", "Doe", "", "M", "B", new DateTime(1980, 1, 1), "123-45-6789", 72);

            // Act/Assert
            Assert.Throws<CaseArgumentException>(() => newCase.RemovePerson(anotherPerson));
        }
        [Fact]
        public void Should_Throw_CaseArgumentException_If_OccurredOnExactDate_After_ReportedOnDate()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            DateTime occurredOnExactDate = new DateTime(2020, 1, 3);

            // Act/Assert
            Assert.Throws<CaseArgumentException>(() => newCase.UpdateOccurredOnExactDate(occurredOnExactDate));
        }
        [Fact]
        public void Should_Throw_CaseArgumentException_If_ReportedOnDate_Before_OccurredOnExactDate()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            DateTime newReportedOnDate = new DateTime(2019, 12, 31);

            // Act/Assert
            Assert.Throws<CaseArgumentException>(() => newCase.UpdateReportedOnDate(newReportedOnDate));
        }
        [Fact]
        public void Should_Throw_CaseArgumentException_If_ReportedOnDate_Before_OccurredBetweenDateEnd()
        {
            // Arrange
            Case newCase = _factory.CreateCase(2);
            DateTime newReportedOnDate = new DateTime(2019, 1, 1);

            // Act/Assert
            Assert.Throws<CaseArgumentException>(() => newCase.UpdateReportedOnDate(newReportedOnDate));
        }
        [Fact]
        public void Should_Clear_OccurredBetweenDates_When_Given_OccurredOnExactDate()
        {
            // Arrange
            Case newCase = _factory.CreateCase(2);
            DateTime newOccurredOnExactDate = new DateTime(2020, 1, 1);

            // Act
            newCase.UpdateOccurredOnExactDate(newOccurredOnExactDate);

            // Assert
            Assert.Null(newCase.OccurredBetweenStartDate);
            Assert.Null(newCase.OccurredBetweenEndDate);
            Assert.Equal(newOccurredOnExactDate, newCase.OccurredOnExactDate);
        }
        [Fact]
        public void Should_Clear_OccurredOnExactDate_When_Given_OccurredBetweenDates()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            DateTime occurredBetweenStartDate = new DateTime(2019, 12, 30);
            DateTime occurredBetweenEndDate = new DateTime(2019, 12, 31);

            // Act
            newCase.UpdateOccurredBetweenDates(occurredBetweenStartDate, occurredBetweenEndDate);

            // Assert
            Assert.Null(newCase.OccurredOnExactDate);
            Assert.Equal(occurredBetweenStartDate, newCase.OccurredBetweenStartDate);
            Assert.Equal(occurredBetweenEndDate, newCase.OccurredBetweenEndDate);
        }
        [Fact]
        public void Should_Throw_CaseArgumentException_For_OccurredBetweenStartDate_Without_OccurredBetweenEndDate()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            DateTime occurredBetweenStartDate = new DateTime(2019, 12, 30);

            // Act/Assert
            Assert.Throws<CaseArgumentException>(() => newCase.UpdateOccurredBetweenDates(occurredBetweenStartDate));
        }
        [Fact]
        public void Should_Throw_CaseArgumentException_For_OccurredBetweenStartDate_After_OccurredBetweenEndDate()
        {
            // Arrange
            Case newCase = _factory.CreateCase(2);
            DateTime newOccurredBetweenStartDate = new DateTime(2020, 1, 1);

            // Act/Assert
            Assert.Throws<CaseArgumentException>(() => newCase.UpdateOccurredBetweenDates(newOccurredBetweenStartDate));
        }
        [Fact]
        public void Should_Throw_CaseArgumentException_For_OccurredBetweenEndDate_Before_OccurredBetweenStartDate()
        {
            // Arrange
            Case newCase = _factory.CreateCase(2);
            DateTime newOccurredBetweenEndDate = new DateTime(2019, 12, 1);

            // Act/Assert
            Assert.Throws<CaseArgumentException>(() => newCase.UpdateOccurredBetweenDates(null, newOccurredBetweenEndDate));
        }
        [Fact]
        public void Should_Throw_CaseArgumentException_For_OccurredBetweenEndDate_Without_OccurredBetweenStartDate()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            DateTime newOccurredBetweenEndDate = new DateTime(2019, 12, 31);

            // Act/Assert
            Assert.Throws<CaseArgumentException>(() => newCase.UpdateOccurredBetweenDates(null, newOccurredBetweenEndDate));
        }
        [Fact]
        public void Should_Throw_CaseArgumentException_For_OccurredBetweenStartDate_After_OccurredBetweenEndDate_When_Both_Provided()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            DateTime occurredBetweenStartDate = new DateTime(2019, 12, 31);
            DateTime occurredBetweenEndDate = new DateTime(2019, 12, 30);

            // Act/Assert
            Assert.Throws<CaseArgumentException>(() => newCase.UpdateOccurredBetweenDates(occurredBetweenStartDate, occurredBetweenEndDate));
        }
        [Fact]
        public void Should_Throw_CaseArgumentException_When_Removing_Offense_Not_In_CaseOffenses()
        {
            // Arrange
            Case newCase = _factory.CreateCase();
            OffenseType newOffenseType = _factory.CreateOffenseType();
            newCase.AddOffense(newOffenseType);
            OffenseType secondOffenseType = new OffenseType("New Type", "N");

            // Act/Assert
            Assert.Throws<CaseArgumentException>(() => newCase.RemoveOffense(secondOffenseType));
        }
    }
}
