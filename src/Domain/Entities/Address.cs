using CaseCore.Domain.Common;
using CaseCore.Domain.Enums;
using CaseCore.Domain.Exceptions.Entities;
using CaseCore.Domain.Types;
using System;
using System.Text.RegularExpressions;

namespace CaseCore.Domain.Entities
{
    /// <summary>
    /// Domain Entity that represents a physical or mailing address.
    /// </summary>
    public class Address : BaseEntity
    {
        private Address()
        {
        }
        /// <summary>
        /// Creates a new Address instance from the provided parameters.
        /// </summary>
        /// <param name="addressTypeId">The id of the <see cref="Types.AddressType"/> of the Address.</param>
        /// <param name="street">The street address, e.g. "123 Anywhere St." Required, cannot be null/whitespace/empty string.</param>
        /// <param name="suite">The suite/apartment/room number. This is an optional field.</param>
        /// <param name="city">The name of the city in which the address is located. Required, cannot be null/whitespace/empty string.</param>
        /// <param name="state">The 2-digit Postal Abbreviation for the state in which the address is located. Required, cannot be null/whitespace/empty string.</param>        
        /// <param name="zipCode">The 5-digit ZIP code for the address. Required, cannot be null/whitespace/empty string.</param>
        public Address(int addressTypeId, string street, string suite, string city, string state, string zipCode)
        {
            UpdateTypeId(addressTypeId);
            UpdateStreet(street);
            UpdateSuite(suite);
            UpdateCity(city);
            UpdateState(state);
            UpdateZip(zipCode);
        }
        /// <summary>
        /// Creates a new Address instance from the provided parameters.
        /// </summary>
        /// <param name="addressTypeId">The id of the <see cref="Types.AddressType"/> of the Address.</param>
        /// <param name="street">The street address, e.g. "123 Anywhere St." Required, cannot be null/whitespace/empty string.</param>
        /// <param name="suite">The suite/apartment/room number. This is an optional field.</param>
        /// <param name="city">The name of the city in which the address is located. Required, cannot be null/whitespace/empty string.</param>
        /// <param name="state">The 2-digit Postal Abbreviation for the state in which the address is located. Required, cannot be null/whitespace/empty string.</param>        
        /// <param name="zipCode">The 5-digit ZIP code for the address. Required, cannot be null/whitespace/empty string.</param>
        public Address(int addressTypeId, string street, string suite, string city, string state, string zipCode, AddressMeta meta)
        {
            UpdateTypeId(addressTypeId);
            UpdateStreet(street);
            UpdateSuite(suite);
            UpdateCity(city);
            UpdateState(state);
            UpdateZip(zipCode);
            _meta = meta;
        }
        private int _addressTypeId;
        /// <summary>
        ///  Returns the Id of the <see cref="AddressType"/> associated with the Address.
        /// </summary>
        public int AddressTypeId => _addressTypeId;
        /// <summary>
        /// Returns the <see cref="AddressType"/> associated with the Address.
        /// </summary>
        public AddressType AddressType { get; private set;}
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
        public string StatePostalCode => _state.ToString();
        private string _zip;
        /// <summary>
        /// Returns a string containing the Address's 5-digit ZIP Code.
        /// </summary>
        public string Zip => _zip;
        public string TypeName => AddressType?.Name ?? "Unknown";
        public string TypeAbbreviation => AddressType?.Abbreviation ?? "XX";
        /// <summary>
        /// Returns a string containing the Beat associated with the address.
        /// </summary>
        /// <remarks>
        /// This will return "N/A" if the Address has no meta or if the address's associated Meta information has not been loaded.
        /// </remarks>
        public string Beat => _meta?.Beat ?? "N/A";
        /// <summary>
        /// Returns a string containing the Reporting Area associated with the address.
        /// </summary>
        /// <remarks>
        /// This will return "N/A" if the Address has no meta or if the address's associated Meta information has not been loaded.
        /// </remarks>
        public string ReportingArea => _meta?.ReportingArea ?? "N/A";
        /// <summary>
        /// Returns a double containing the Logitude associated with the address.
        /// </summary>
        /// <remarks>
        /// This will return 0.0 if the Address has no meta or if the address's associated Meta information has not been loaded.
        /// </remarks>
        public double Longitude => _meta?.Longitude ?? 0.0;
        /// <summary>
        /// Returns a double containing the Latitude associated with the address.
        /// </summary>
        /// <remarks>
        /// This will return 0.0 if the Address has no meta or if the address's associated Meta information has not been loaded.
        /// </remarks>
        public double Latitude => _meta?.Latitude ?? 0.0;
        private readonly AddressMeta _meta;
        public string FullAddressText => $"{Street}{(!string.IsNullOrEmpty(Suite) ? $" {Suite}" : "")}, {City}, {StatePostalCode} {Zip}";
        /// <summary>
        /// Updates the id of the <see cref="Types.AddressType"/> associated with the address. 
        /// </summary>
        /// <param name="newAddressTypeId"></param>
        /// <exception cref="AddressArgumentException">
        /// Thrown when the parameter is less than 1.
        /// </exception>
        public void UpdateTypeId(int newAddressTypeId)
        {
            if (newAddressTypeId < 1)
            {
                throw new AddressArgumentException("Cannot update Address Type Id: parameter cannot be less than 1.", nameof(newAddressTypeId));
            }
            _addressTypeId = newAddressTypeId;
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
