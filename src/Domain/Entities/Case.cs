using CaseCore.Common.Attributes;
using CaseCore.Domain.Common;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseCore.Domain.Entities
{
    public class Case : AuditableEntity
    {
        [IgnoreCodeCoverage]
        private Case()
        {

        }
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="caseNumber">A string containing the Case Number associated with the case.</param>
        /// <param name="locationOfIncident">An <see cref="Address"/> representing the Location of Incident for the case.</param>
        /// <param name="occurredOnExactDate">A <see cref="DateTime"/> representing the exact time the incident is known to have occurred.</param>
        /// <param name="reportedOnDate">A <see cref="DateTime"/> representing the Date/Time the incident was reported.</param>
        public Case(string caseNumber, Address locationOfIncident, DateTime occurredOnExactDate, DateTime reportedOnDate) 
        {
            UpdateCaseNumber(caseNumber);            
            UpdateOccurredOnExactDate(occurredOnExactDate);
            UpdateReportedOnDate(reportedOnDate);
            _persons = new List<CasePerson>();
            _addresses = new List<CaseAddress>();
            _caseStatuses = new List<CaseStatus>();
            _caseAssignments = new List<CaseAssignment>();
            _caseOffenses = new List<CaseOffense>();
            AddAddress(locationOfIncident);
        }
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="caseNumber">A string containing the Case Number associated with the case.</param>
        /// <param name="locationOfIncident">An <see cref="Address"/> representing the Location of Incident for the case.</param>
        /// <param name="occurredBetweenStartDate">A <see cref="DateTime"/> representing the start time of the timeframe during which the incident occurred.</param>
        /// <param name="occurredBetweenEndDate">A <see cref="DateTime"/> representing the end date/time of the timeframe during which the incident occurred.</param>
        /// <param name="reportedOnDate">A <see cref="DateTime"/> representing the Date/Time the incident was reported.</param>
        public Case(string caseNumber, Address locationOfIncident, DateTime occurredBetweenStartDate, DateTime occurredBetweenEndDate, DateTime reportedOnDate)
        {
            UpdateCaseNumber(caseNumber);            
            UpdateOccurredBetweenDates(occurredBetweenStartDate, occurredBetweenEndDate);
            UpdateReportedOnDate(reportedOnDate);
            _persons = new List<CasePerson>();
            _addresses = new List<CaseAddress>();
            _caseStatuses = new List<CaseStatus>();
            _caseAssignments = new List<CaseAssignment>();
            _caseOffenses = new List<CaseOffense>();
            AddAddress(locationOfIncident);
        }

        private string _caseNumber;
        /// <summary>
        /// A string representing the Case Number for the incident.
        /// </summary>
        public string CaseNumber => _caseNumber;
        private DateTime? _occurredBetweenStartDate;
        /// <summary>
        /// Represents the start date/time of the datetime range during which the incident occurred.
        /// </summary>
        /// <remarks>
        /// A Case should have either:
        /// 1. A Start/End Date representing a Timeframe during which the incident occurred, or
        /// 2. An exact time the incident occurred, if known.
        /// </remarks>
        public DateTime? OccurredBetweenStartDate => _occurredBetweenStartDate;
        private DateTime? _occurredBetweenEndDate;
        /// <summary>
        /// Represents the end date/time of the datetime range during which the incident occurred.
        /// </summary>
        /// <remarks>
        /// A Case should have either:
        /// 1. A Start/End Date representing a Timeframe during which the incident occurred, or
        /// 2. An exact time the incident occurred, if known.
        /// </remarks>
        public DateTime? OccurredBetweenEndDate => _occurredBetweenEndDate;
        private DateTime? _occurredOnExactDate;
        /// <summary>
        /// Represents the exact date/time that an incident occurred.
        /// </summary>
        public DateTime? OccurredOnExactDate => _occurredOnExactDate;
        private DateTime? _reportedOnDate;
        public DateTime? ReportedOnDate => _reportedOnDate;
        private readonly List<CaseOffense> _caseOffenses;
        /// <summary>
        /// Returns a readonly list of <see cref="Entities.CaseOffense"/> associated with the case.
        /// </summary>
        public virtual IEnumerable<CaseOffense> CaseOffenses => _caseOffenses.AsReadOnly();

        private readonly List<CasePerson> _persons;
        /// <summary>
        /// Returns a readonly list of <see cref="CasePerson"/> entities associated with this case.
        /// </summary>
        public virtual IEnumerable<CasePerson> Persons => _persons.AsReadOnly();
        private readonly List<CaseAddress> _addresses;
        /// <summary>
        /// Returns a readonly list of <see cref="CaseAddress"/> entities associated with this case.
        /// </summary>
        public virtual IEnumerable<CaseAddress> Addresses => _addresses.AsReadOnly();
        private readonly List<CaseStatus> _caseStatuses;
        /// <summary>
        /// Returns a readonly list of <see cref="CaseStatus"/> entities associated with this case.
        /// </summary>
        public virtual IEnumerable<CaseStatus> CaseStatuses => _caseStatuses.AsReadOnly();
        /// <summary>
        /// Attempts to return the most recent entry in the Case Statuses collection, which should represent the Case's Current Status.
        /// </summary>
        public CaseStatus CurrentStatus => _caseStatuses?.OrderByDescending(x => x.StatusDate).FirstOrDefault();
        private readonly List<CaseAssignment> _caseAssignments;
        /// <summary>
        /// Returns a readonly list of <see cref="CaseAssignment"/> entities associated with the case.
        /// </summary>
        public virtual IEnumerable<CaseAssignment> CaseAssignments => _caseAssignments;
        /// <summary>
        /// Attempts to return the most recent entry in the Case Assignments collection, which should represent the Case's Current Assignment.
        /// </summary>
        public CaseAssignment CurrentAssignment => _caseAssignments?.OrderByDescending(x => x.AssignmentDate).FirstOrDefault();
        public void UpdateCaseNumber(string newCaseNumber)
        {
            if (string.IsNullOrWhiteSpace(newCaseNumber))
            {
                throw new CaseArgumentException("Cannot update Case Number: parameter cannot be null or whitespace.", nameof(newCaseNumber));
            }
            _caseNumber = newCaseNumber;
        }
        /// <summary>
        /// Adds an address to the Case's Address collection.
        /// </summary>
        /// <param name="address">A <see cref="Address"/> object.</param>
        public void AddAddress(Address address)
        {
            _addresses.Add(new CaseAddress(this, address));
        }
        /// <summary>
        /// Removes an address from the Case's Address collection.
        /// </summary>
        /// <param name="address"></param>
        /// <exception cref="CaseArgumentException">Thrown when the provided address parameter is not found in the Case's address collection.</exception>
        public void RemoveAddress(Address address)
        {
            CaseAddress toRemove = _addresses?.Find(x => x.Address == address);
            if (toRemove == null)
            {
                throw new CaseArgumentException("Cannot remove Address from Case: Address not found in Addresses Collection.", nameof(address));
            }
            _addresses.Remove(toRemove);
        }
        /// <summary>
        /// Adds a <see cref="Person"/> to the Case's Persons Collection.
        /// </summary>
        /// <param name="person">The <see cref="Person"/> object to add.</param>
        public void AddPerson(Person person)
        {
            _persons.Add(new CasePerson(this,person));
        }
        /// <summary>
        /// Removes a <see cref="Person"/> from the Case's Persons Collection
        /// </summary>
        /// <param name="person">The <see cref="Person"/> to remove.</param>
        /// <exception cref="CaseArgumentException">Thrown if the person provided in the parameter was not found in the Case's Persons Collection.</exception>
        public void RemovePerson(Person person)
        {
            CasePerson toRemove = _persons.Find(x => x.Person == person);
            if(toRemove == null)
            {
                throw new CaseArgumentException("Cannot remove Person from Case: Person not found in Case Persons collection.", nameof(person));
            }
            _persons.Remove(toRemove);
        }
        /// <summary>
        /// Updates the <see cref="CaseStatus"/> of the Case by creating a new <see cref="CaseStatus"/> record.
        /// </summary>
        /// <param name="caseStatusType">The <see cref="CaseStatusType"/> of the new Status.</param>
        /// <param name="caseStatusEffectiveDate">A <see cref="DateTime"/> representing the effective date of the status.</param>
        /// <param name="remarks">A string containing optional remarks for the status entry.</param>
        public void UpdateCaseStatus(CaseStatusType caseStatusType, DateTime caseStatusEffectiveDate, string remarks = "")
        {
            _caseStatuses.Add(new CaseStatus(this, caseStatusType, caseStatusEffectiveDate, remarks));
        }
        /// <summary>
        /// Updates the <see cref="CaseAssignment"/> of the Case by creating a new <see cref="CaseAssignment"/> record.
        /// </summary>
        /// <param name="assignmentType">A <see cref="CaseAssignmentType"/> object.</param>
        /// <param name="assignedToUserName">A string containing the username of the assignee.</param>
        /// <param name="assignmentDate">A <see cref="DateTime"/> representing the assignment effective date.</param>
        /// <param name="remarks">An optional string containing remarks about the assignment.</param>
        public void UpdateCaseAssignment(CaseAssignmentType assignmentType, string assignedToUserName, DateTime assignmentDate, string remarks = "")
        {
            _caseAssignments.Add(new CaseAssignment(this, assignmentType, assignedToUserName, assignmentDate, remarks));
        }
        /// <summary>
        /// Updates the Occurred on Exact Date.
        /// </summary>
        /// <param name="newDate">A DateTime representing the exact Date/Time the Case incident occurred.</param>
        /// <exception cref="CaseArgumentException">Thrown if the provided parameter date is greater than the Case's Reported On date.</exception>        
        /// <remarks>Calling this method will clear any values in the Cases's Occurred Between Start/End Date fields. A Case should have either an exact occurred on date, or an occurred between start/end date.</remarks>
        public void UpdateOccurredOnExactDate(DateTime newDate)
        {
            if (newDate > _reportedOnDate)
            {
                throw new CaseArgumentException("Cannot update Case Occurred on Exact Date: Occurred on Date cannot be after Reported On Date.", nameof(newDate));
            }
            _occurredOnExactDate = newDate;
            _occurredBetweenStartDate = null;
            _occurredBetweenEndDate = null;
        }
        public void UpdateReportedOnDate(DateTime newDate)
        {
            if (_occurredOnExactDate != null && _occurredOnExactDate > newDate)
            {
                throw new CaseArgumentException("Cannot update Case Reported on Date: Reported On Date must be after Occurred on Exact Date.", nameof(newDate));
            }
            else if (_occurredBetweenEndDate != null && _occurredBetweenEndDate > newDate)
            {
                throw new CaseArgumentException("Cannot update Case Reported on Date: Reported On Date must be after Occurred Between End Date.", nameof(newDate));
            }
            _reportedOnDate = newDate;
        }
        /// <summary>
        /// Updates the Date Range during which the incident occurred.
        /// </summary>
        /// <param name="startDate">A <see cref="DateTime?"/> object representing the Start Date/Time of the period in which the incident occurred.</param>
        /// <param name="endDate">A <see cref="DateTime?"/> object representing the End Date/Time of the period in which the incident occurrred.</param>
        /// <remarks>A successfull call to set the Date Range using this method will clear any value in the OccurredOnExactDate field.</remarks>
        public void UpdateOccurredBetweenDates(DateTime? startDate = null, DateTime? endDate = null)
        {
            if (startDate != null && endDate == null) // user wants to update only the start date
            {
                if (_occurredBetweenEndDate == null) // if the current occurred between end date is null, we cannot update the date range without the endDate parameter.
                {
                    throw new CaseArgumentException("Cannot update Case Occurred Between Start Date without the Occurred Between End Date", nameof(startDate));

                }
                else if (_occurredBetweenEndDate < startDate)
                {
                    throw new CaseArgumentException("Cannot update Case Occurred Between Start Date: The current value of Occurred between End Date is before the provided Start Date Value.", nameof(startDate));
                }
                _occurredBetweenStartDate = startDate;
            }
            else if (startDate == null && endDate != null) // user wants to update only the end date.
            {
                if (_occurredBetweenStartDate == null) // if the current occurred between start date is null, we cannot update the date range without the startDate parameter.
                {
                    throw new CaseArgumentException("Cannot update Case Occurred Between End Date without the Occurred Between Start Date.", nameof(endDate));
                }
                else if (_occurredBetweenStartDate > endDate)
                {
                    throw new CaseArgumentException("Cannot update Case Occurred Between End Date: The current value of Occurred between Start Date is after the provided End Date Value.", nameof(endDate));
                }
                _occurredBetweenEndDate = endDate;
            }
            else
            {
                if (startDate > endDate)
                {
                    throw new CaseArgumentException("Cannot update Case Occurred Between date Range: the provided StartDate parameter is after the provided EndDate parameter", nameof(startDate));
                }
                _occurredBetweenStartDate = startDate;
                _occurredBetweenEndDate = endDate;
                _occurredOnExactDate = null;
            }                
        }
        /// <summary>
        /// Adds an offense to the Case's offense type list.
        /// </summary>
        /// <param name="offenseType">A <see cref="OffenseType"/></param>
        public void AddOffense(OffenseType offenseType)
        {
            _caseOffenses.Add(new CaseOffense(this, offenseType));
        }
        /// <summary>
        /// Removes an offense from the Case's offenses list.
        /// </summary>
        /// <param name="offenseType">The <see cref="OffenseType"/> to remove.</param>
        public void RemoveOffense(OffenseType offenseType)
        {
            CaseOffense toRemove = _caseOffenses.FirstOrDefault(x => x.OffenseType == offenseType);
            if (toRemove == null)
            {
                throw new CaseArgumentException("Cannot remove offense from Case offense list: Offense was not found in Offense collection.", nameof(offenseType));
            }
            _caseOffenses.Remove(toRemove);
        }
    }
}
