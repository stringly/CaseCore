using CaseCore.Common.Attributes;
using CaseCore.Domain.Common;
using CaseCore.Domain.Enums;
using CaseCore.Domain.Exceptions.Entities.Address;
using CaseCore.Domain.Types;
using System;
using System.Text.RegularExpressions;

namespace CaseCore.Domain.Entities
{
    /// <summary>
    /// Domain Entity that represents a physical or mailing address.
    /// </summary>
    public class Address : AuditableEntity
    {   
        [IgnoreCodeCoverage]
        private Address()
        {
        }
        /// <summary>
        /// Creates a new Address instance from the provided parameters.
        /// </summary>
        /// <param name="type">The <see cref="AddressType"/> of the address being created.</param>
        /// <param name="street">The street address, e.g. "123 Anywhere St." Required, cannot be null/whitespace/empty string.</param>
        /// <param name="suite">The suite/apartment/room number. This is an optional field.</param>
        /// <param name="city">The name of the city in which the address is located. Required, cannot be null/whitespace/empty string.</param>
        /// <param name="state">The 2-digit Postal Abbreviation for the state in which the address is located. Required, cannot be null/whitespace/empty string.</param>        
        /// <param name="zipCode">The 5-digit ZIP code for the address. Required, cannot be null/whitespace/empty string.</param>
        public Address(AddressType type, string street, string suite, string city, string state, string zipCode)
        {
            UpdateType(type);
            UpdateStreet(street);
            UpdateSuite(suite);
            UpdateCity(city);
            UpdateState(state);
            UpdateZip(zipCode);
        }
        /// <summary>
        /// Creates a new Address instance from the provided parameters.
        /// </summary>
        /// <param name="type">The <see cref="AddressType"/> of the address being created.</param>
        /// <param name="street">The street address, e.g. "123 Anywhere St." Required, cannot be null/whitespace/empty string.</param>
        /// <param name="suite">The suite/apartment/room number. This is an optional field.</param>
        /// <param name="city">The name of the city in which the address is located. Required, cannot be null/whitespace/empty string.</param>
        /// <param name="state">The 2-digit Postal Abbreviation for the state in which the address is located. Required, cannot be null/whitespace/empty string.</param>        
        /// <param name="zipCode">The 5-digit ZIP code for the address. Required, cannot be null/whitespace/empty string.</param>
        /// <param name="latitude">A double in the range of -90.0 to 90.0 that represents the latitude coordinate of the address. Defaults to 0.0.</param>
        /// <param name="longitude">A double in the range of -180.0 to 180.0 that represents the longitude coordinate of the address. Defaults to 0.0.</param>
        public Address(AddressType type, string street, string suite, string city, string state, string zipCode, double latitude = 0.0, double longitude = 0.0)
        {
            UpdateType(type);
            UpdateStreet(street);
            UpdateSuite(suite);
            UpdateCity(city);
            UpdateState(state);
            UpdateZip(zipCode); 
            UpdateCoordinates(latitude, longitude);
        }
        /// <summary>
        /// Creates a new Address instance from the provided parameters.
        /// </summary>
        /// <param name="type">The <see cref="AddressType"/> of the address being created.</param>
        /// <param name="street">The street address, e.g. "123 Anywhere St." Required, cannot be null/whitespace/empty string.</param>
        /// <param name="suite">The suite/apartment/room number. This is an optional field.</param>
        /// <param name="city">The name of the city in which the address is located. Required, cannot be null/whitespace/empty string.</param>
        /// <param name="state">The 2-digit Postal Abbreviation for the state in which the address is located. Required, cannot be null/whitespace/empty string.</param>        
        /// <param name="zipCode">The 5-digit ZIP code for the address. Required, cannot be null/whitespace/empty string.</param>
        /// <param name="beat">A string of 5 characters or fewer representing the beat associated with the address.</param>
        /// <param name="reportingArea">A string of 10 characters or fewer representing the Reporting Area associated with the address.</param>
        public Address(AddressType type, string street, string suite, string city, string state, string zipCode, string beat, string reportingArea)
        {
            UpdateType(type);
            UpdateStreet(street);
            UpdateSuite(suite);
            UpdateCity(city);
            UpdateState(state);
            UpdateZip(zipCode);
            UpdateBeat(beat);
            UpdateReportingArea(reportingArea);
        }
        /// <summary>
        /// Creates a new Address instance from the provided parameters.
        /// </summary>
        /// <param name="type">The <see cref="AddressType"/> of the address being created.</param>
        /// <param name="street">The street address, e.g. "123 Anywhere St." Required, cannot be null/whitespace/empty string.</param>
        /// <param name="suite">The suite/apartment/room number. This is an optional field.</param>
        /// <param name="city">The name of the city in which the address is located. Required, cannot be null/whitespace/empty string.</param>
        /// <param name="state">The 2-digit Postal Abbreviation for the state in which the address is located. Required, cannot be null/whitespace/empty string.</param>        
        /// <param name="zipCode">The 5-digit ZIP code for the address. Required, cannot be null/whitespace/empty string.</param>
        /// <param name="beat">A string of 5 characters or fewer representing the beat associated with the address.</param>
        /// <param name="reportingArea">A string of 10 characters or fewer representing the Reporting Area associated with the address.</param>
        /// <param name="latitude">A double in the range of -90.0 to 90.0 that represents the latitude coordinate of the address. Defaults to 0.0.</param>
        /// <param name="longitude">A double in the range of -180.0 to 180.0 that represents the longitude coordinate of the address. Defaults to 0.0.</param>
        public Address(AddressType type, string street, string suite, string city, string state, string zipCode, string beat, string reportingArea, double latitude = 0.0, double longitude = 0.0)
        {
            UpdateType(type);
            UpdateStreet(street);
            UpdateSuite(suite);
            UpdateCity(city);
            UpdateState(state);
            UpdateZip(zipCode);
            UpdateBeat(beat);
            UpdateReportingArea(reportingArea);
            UpdateCoordinates(latitude, longitude);
        }
        /// <summary>
        /// The <see cref="AddressType"/> of the Address.
        /// </summary>
        public AddressType AddressType { get; private set;}
        /// <summary>
        /// The ID of the <see cref="AddressType"/> of the Address.
        /// </summary>
        [IgnoreCodeCoverage]
        public int AddressTypeId { get; private set; }
        private string _street;
        /// <summary>
        /// Returns a string with the Address's Street Address.
        /// </summary>
        public string Street => _street;
        private string _suite;
        /// <summary>
        /// Returns a string containing the Address's secondary field, i.e. Apartment #, Suite #, etc.
        /// </summary>
        public string Suite => _suite;
        private string _city;
        /// <summary>
        /// Returns a string containing the Address's City.
        /// </summary>
        public string City => _city;
        private State _state;
        /// <summary>
        /// Represents the <see cref="Enums.State"/> associated with the address.
        /// </summary>
        public State State => _state;
        /// <summary>
        /// Returns the State enum as as string.
        /// </summary>
        public string StatePostalCode => _state.ToString();

        private string _zip;
        /// <summary>
        /// Returns a string containing the Address's 5-digit ZIP Code.
        /// </summary>
        public string Zip => _zip;
        private string _beat;
        /// <summary>
        /// Returns a string containing the Beat associated with the address.
        /// </summary>
        public string Beat => _beat;
        private string _reportingArea;
        /// <summary>
        /// Returns a string containing the reporting area associated with the address.
        /// </summary>
        public string ReportingArea => _reportingArea;
        private double? _longitude;
        /// <summary>
        /// Returns a double containing the Longitude coordinate for the address.
        /// </summary>
        public double? Longitude => _longitude;
        private double? _latitude;
        /// <summary>
        /// Returns a double containing the Address's Latitude.
        /// </summary>
        public double? Latitude => _latitude;
        /// <summary>
        /// Returns the Address as a string containing the full mailing address.
        /// </summary>
        public string FullAddressText => $"{Street}{(!string.IsNullOrEmpty(Suite) ? $" {Suite}" : "")}, {City}, {State} {Zip}";
        /// <summary>
        /// Updates the <see cref="AddressType"/> associated with the Address.
        /// </summary>
        /// <param name="newType">The new <see cref="AddressType"/></param>
        public void UpdateType(AddressType newType)
        {
            AddressType = newType;
        }
        /// <summary>
        /// Updates the Street of the Address.
        /// </summary>
        /// <param name="newStreet">A string containing the street address portion of the address, i.e. "123 Anywhere St." Max 500 characters.</param>
        /// <exception cref="AddressArgumentException">
        /// Thrown when the parameter is null, whitespace, or more than 500 characters.
        /// </exception>
        public void UpdateStreet(string newStreet)
        {
            if (string.IsNullOrWhiteSpace(newStreet))
            {
                throw new AddressArgumentException("Cannot update Address Street: parameter cannot be null or whitespace.", nameof(newStreet));
            }
            else if (newStreet.Length > 500)
            {
                throw new AddressArgumentException("Cannot update Address Street: parameter must be 500 characters or fewer.", nameof(newStreet));
            }
            _street = newStreet;
        }
        /// <summary>
        /// Updates the Suite of the Address.
        /// </summary>
        /// <param name="newSuite">A string containing the suite address portion of the address, i.e. "Room #3." Max 500 characters.</param>
        /// <exception cref="AddressArgumentException">
        /// Thrown when the parameter is more than 500 characters.
        /// </exception>
        public void UpdateSuite(string newSuite)
        {
            if (newSuite.Length > 500)
            {
                throw new AddressArgumentException("Cannot update Address Suite: parameter must be 500 characters or fewer.", nameof(newSuite));
            }
            _suite = newSuite;
        }
        /// <summary>
        /// Updates the City of the Address.
        /// </summary>
        /// <param name="newCity">A string containing the city address portion of the address, i.e. "Yourtown." Max 500 characters.</param>
        /// <exception cref="AddressArgumentException">
        /// Thrown when the parameter is null, whitespace, or more than 500 characters.
        /// </exception>
        public void UpdateCity(string newCity)
        {
            if (string.IsNullOrWhiteSpace(newCity))
            {
                throw new AddressArgumentException("Cannot update Address City: parameter cannot be null or whitespace.", nameof(newCity));
            }
            else if (newCity.Length > 500)
            {
                throw new AddressArgumentException("Cannot update Address City: parameter must be 500 characters or fewer.", nameof(newCity));
            }
            _city = newCity;
        }
        /// <summary>
        /// Updates the State of the Address.
        /// </summary>
        /// <param name="newState">A string containing a valid 2-digit state postal code.</param>
        /// <exception cref="AddressArgumentException">
        /// Thrown when the parameter cannot be converted to a valid <see cref="State"/>
        /// </exception>
        public void UpdateState(string newState)
        {
            try
            {
                _state = (State)Enum.Parse(typeof(State), newState);
            }
            catch (ArgumentException)
            {
                throw new AddressArgumentException("Cannot update Address State: parameter could not be converted to a valid State postal code.", nameof(newState));
            }
        }
        /// <summary>
        /// Updates the Zip Code of the Address.
        /// </summary>
        /// <param name="newZip">A string containing a valid US/CA zip code.</param>
        /// <exception cref="AddressArgumentException">
        /// Thrown when the parameter is not a valid US/CA Zip code.
        /// </exception>
        public void UpdateZip(string newZip)
        {
            if (!IsUSOrCanadianZipCode(newZip))
            {
                throw new AddressArgumentException("Cannot update Address Zip Code: parameter is not a valid US/Canadian Zip Code.", nameof(newZip));
            }
            _zip = newZip;
        }
        /// <summary>
        /// Updates the Beat associated with the Address's meta information.
        /// </summary>
        /// <param name="newBeat">A string of 5 characters or fewer representing the beat associated with the address.</param>
        /// <exception cref="AddressArgumentException">
        /// Thrown when the provided parameter is null, whitespace, or more than 5 characters.
        /// </exception>
        public void UpdateBeat(string newBeat)
        {
            if (string.IsNullOrWhiteSpace(newBeat))
            {
                throw new AddressArgumentException("Cannot update Address Beat: parameter cannot be null or whitespace.", nameof(newBeat));
            }
            else if (newBeat.Length > 5)
            {
                throw new AddressArgumentException("Cannot update Address Beat: parameter must be 5 characters or fewer.", nameof(newBeat));
            }
            else
            {
                _beat = newBeat;
            }
        }
        /// <summary>
        /// Updates the Reporting Area associated with the Address's meta information.
        /// </summary>
        /// <param name="newReportingArea">A string of 10 characters or fewer representing the Reporting Area associated with the address.</param>
        /// <exception cref="AddressArgumentException">
        /// Thrown when the provided parameter is null, whitespace, or more than 10 characters.
        /// </exception>
        public void UpdateReportingArea(string newReportingArea)
        {
            if (string.IsNullOrWhiteSpace(newReportingArea))
            {
                throw new AddressArgumentException("Cannot update Address Reporting Area: parameter cannot be null or whitespace.", nameof(newReportingArea));
            }
            else if (newReportingArea.Length > 10)
            {
                throw new AddressArgumentException("Cannot update Address Reporting Area: parameter must be 10 characters or fewer.", nameof(newReportingArea));
            }
            else
            {
                _reportingArea = newReportingArea;
            }
        }
        /// <summary>
        /// Updates the GPS coordinates associated with the address.
        /// </summary>
        /// <param name="latitude">A double in the range of -90.0 to 90.0.</param>
        /// <param name="longitude">A double in the range of -180.0 to 180.0.</param>
        /// <exception cref="AddressArgumentException">
        /// Thrown when the latitude paramater is not within the range of -90.0 to 90.0 or the longitude parameter is not within the range of -180.0 to 180.0.
        /// </exception>
        public void UpdateCoordinates(double? latitude = null, double? longitude = null)
        {
            if (latitude != null && longitude == null) // User wants to update lat only
            {                
                if (_longitude == null) 
                {
                    // if current long property is null, we cannot update coords with just lat
                    throw new AddressInvalidOperationException("Cannot update Address Coordinate Latitude: Object Longitude property is null. Both a Latitude and Longitude value are required.");
                }
                else if (latitude > 90.0 || latitude < -90.0)
                {
                    throw new AddressArgumentException("Cannot update Address Latitude: parameter must be between -90.0 and 90.0.", nameof(latitude));
                }
                _latitude = latitude;
            }
            else if (latitude == null && longitude != null) // User wants to update long only
            {
                if (_latitude == null)
                {
                    // if current lat property is null, we cannot update coords with just long
                    throw new AddressInvalidOperationException("Cannot update Address Coordinate Longitude: Object Latitude property is null. Both a Latitude and Longitude value are required.");
                }
                else if (longitude > 180.0 || longitude < -180.0)
                {
                    throw new AddressArgumentException("Cannot update Address Latitude: parameter must be between 180.0 and -180.0.", nameof(longitude));
                }
                _longitude = longitude;
            }
            else
            {
                if (latitude > 90.0 || latitude < -90.0)
                {
                    throw new AddressArgumentException("Cannot update Address Latitude: parameter must be between -90.0 and 90.0.", nameof(latitude));
                }
                else if (longitude > 180.0 || longitude < -180.0)
                {
                    throw new AddressArgumentException("Cannot update Address Latitude: parameter must be between 180.0 and -180.0.", nameof(longitude));
                }
                else
                {
                    _latitude = latitude;
                    _longitude = longitude;
                }
            }
            
        }

        private bool IsUSOrCanadianZipCode(string zipCode)
        {
            var _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
            var _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";
            var validZipCode = true;
            if ((!Regex.Match(zipCode, _usZipRegEx).Success) && (!Regex.Match(zipCode, _caZipRegEx).Success))
            {
                validZipCode = false;
            }
            return validZipCode;
        }
    }
}
