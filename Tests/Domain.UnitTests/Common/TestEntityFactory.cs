using CaseCore.Domain.Common;
using CaseCore.Domain.Entities;
using CaseCore.Domain.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CaseCore.Domain.UnitTests.Common
{
    public class TestEntityFactory
    {
        public TestEntityFactory()
        {
        }
        #region Entities
        /// <summary>
        /// Factory method that creates a basic address for test methods.
        /// </summary>
        /// <oaram name="constructor">Integer that determines which constructor to call on the Address object. Valid values are:
        /// <list type="bullet">
        /// <item>1 (Default)>Will invoke constructor 1, which will populate AddressType, street, suite, city, state, and zip.</description></item>
        /// <item>2<description>Will invoke constructor 2, which will populate AddressType, street, suite, city, state, zip, latitide and longitude.</description></item>
        /// <item>3<description>Will invoke constructor 3, which will populate AddressType, street, suite, city, state, zip, beat, and reportingArea.</description></item>
        /// <item>4<description>Will invoke constructor 4, which will populate AddressType, street, suite, city, state, zip, beat, reportingArea, latitude and longitude.</description></item>
        /// </list>
        /// </oaram>
        /// <returns>A <see cref="Address"/> object.</returns>
        public Address CreateAddress(int constructor = 1)
        {
            AddressType testType = CreateAddressType();
            string street = "123 Anywhere St.";
            string suite = "Apartment #3";
            string city = "Yourtown";
            string state = "MD";
            string zip = "12345";
            string beat = "B3";
            string reportingArea = "118";
            double latitude = 89.0;
            double longitude = 179.0;
            return constructor switch
            {
                1 => new Address(testType, street, suite, city, state, zip),
                2 => new Address(testType, street, suite, city, state, zip, latitude, longitude),
                3 => new Address(testType, street, suite, city, state, zip, beat, reportingArea),
                4 => new Address(testType, street, suite, city, state, zip, beat, reportingArea, latitude, longitude),
                _ => new Address(testType, street, suite, city, state, zip),
            };
        }
        /// <summary>
        /// Factory Method that creates a default Person for Test Methods.
        /// </summary>
        /// <returns>A <see cref="Person"/> object with default values.</returns>
        public Person CreatePerson()
        {
            // Arrange
            PersonType testType = CreatePersonType();
            string prefix = "Mr";
            string firstName = "John";
            string middleName = "Que";
            string lastName = "Public";
            string suffix = "Jr.";
            string gender = "M";
            string race = "W";
            DateTime dob = new DateTime(1980, 1, 1);
            string ssn = "123-45-6789";

            return new Person(testType, prefix, firstName, middleName, lastName, suffix, gender, race, dob, ssn);
        }
        public Case CreateCase(int constructor = 1)
        {
            string caseNumber = "PP12345600001111";
            Address newAddress = CreateAddress();
            DateTime occurredOnDate = new DateTime(2020, 1, 1);
            DateTime reportedOnDate = new DateTime(2020, 1, 2);
            DateTime occurredBetweenStartDate = new DateTime(2019, 12, 30);
            DateTime occurredBetweenEndDate = new DateTime(2019, 12, 31);
            return constructor switch
            {
                1 => new Case(caseNumber, newAddress, occurredOnDate, reportedOnDate),
                2 => new Case(caseNumber, newAddress, occurredBetweenStartDate, occurredBetweenEndDate, reportedOnDate),
                _ => new Case(caseNumber, newAddress, occurredOnDate, reportedOnDate)
            };
        }
        public CaseAssignment CreateCaseAssignment()
        {            
            Case newCase = CreateCase();
            CaseAssignmentType newAssignmentType = CreateCaseAssignmentType();
            string newUser = "tesetUser";
            DateTime newAssignmentDate = new DateTime(2021, 8, 9);
            string newRemarks = "test remarks";
            return new CaseAssignment(newCase, newAssignmentType, newUser, newAssignmentDate, newRemarks);
        }
        public CaseStatus CreateCaseStatus()
        {
            Case newCase = CreateCase();
            CaseStatusType newCaseStatusType = CreateCaseStatusType();
            DateTime newDate = new DateTime(2021, 8, 9);
            string newRemarks = "Test Remarks";
            return new CaseStatus(newCase, newCaseStatusType, newDate, newRemarks);
        }
        #endregion Entities
        #region Types

        public AddressType CreateAddressType()
        {
            return new AddressType("Test", "X");
        }
        public PersonType CreatePersonType()
        {
            return new PersonType("Test", "X");
        }
        public CaseStatusType CreateCaseStatusType()
        {
            return new CaseStatusType("Test");
        }
        public CaseAssignmentType CreateCaseAssignmentType()
        {
            return new CaseAssignmentType("Test");
        }
        public PhoneNumberType CreatePhoneNumberType()
        {
            return new PhoneNumberType("Test", "X");
        }
        public OffenseType CreateOffenseType()
        {
            return new OffenseType("Test", "X");
        }
        #endregion Types
        #region ValueObjects
        /// <summary>
        /// Test implementation of ValueObject as a Point
        /// </summary>
        public class Point : ValueObject
        {
            public int X { get; set; }
            public int Y { get; set; }


            private Point() { }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            protected override IEnumerable<object> GetAtomicValues()
            {
                yield return X;
                yield return Y;
            }
        }
        #endregion ValueObjects
        #region TestEnums
        public enum TestEnums {
            [Description("This Enum has a description")]
            TestWithDescription,
            TestWithoutDescription
        }



        #endregion TestEnums
    }
}
