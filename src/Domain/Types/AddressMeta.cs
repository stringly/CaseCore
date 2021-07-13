using CaseCore.Domain.Common;
using CaseCore.Domain.Entities;
using CaseCore.Domain.Exceptions.Types;

namespace CaseCore.Domain.Types
{

    public class AddressMeta : BaseEntity
    {
        /// <summary>
        /// Creates a new instance of the class
        /// </summary>
        /// <param name="beat">A string of 5 characters or fewer representing the beat associated with the address.</param>
        /// <param name="reportingArea">A string of 10 characters or fewer representing the Reporting Area associated with the address.</param>
        /// <param name="latitude">A double in the range of -90.0 to 90.0 that represents the latitude coordinate of the address. Defaults to 0.0.</param>
        /// <param name="longitude">A double in the range of -180.0 to 180.0 that represents the longitude coordinate of the address. Defaults to 0.0.</param>
        public AddressMeta(string beat, string reportingArea, double latitude = 0.0, double longitude = 0.0)
        {
            UpdateBeat(beat);
            UpdateReportingArea(reportingArea);
            UpdateCoordinates(latitude, longitude);
        }
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
        private double _longitude;
        /// <summary>
        /// Returns a double containing the Longitude coordinate for the address.
        /// </summary>
        public double Longitude => _longitude;
        private double _latitude;
        public double Latitude => _latitude;
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        /// <summary>
        /// Updates the Beat associated with the Address's meta information.
        /// </summary>
        /// <param name="newBeat">A string of 5 characters or fewer representing the beat associated with the address.</param>
        /// <exception cref="AddressMetaArgumentException">
        /// Thrown when the provided parameter is null, whitespace, or more than 5 characters.
        /// </exception>
        public void UpdateBeat(string newBeat)
        {
            if (string.IsNullOrWhiteSpace(newBeat))
            {
                throw new AddressMetaArgumentException("Cannot update Address Meta Beat: parameter cannot be null or whitespace.", nameof(newBeat));
            }
            else if (newBeat.Length > 5)
            {
                throw new AddressMetaArgumentException("Cannot update Address Meta Beat: parameter must be 5 characters or fewer.", nameof(newBeat));
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
        /// <exception cref="AddressMetaArgumentException">
        /// Thrown when the provided parameter is null, whitespace, or more than 10 characters.
        /// </exception>
        public void UpdateReportingArea(string newReportingArea)
        {
            if (string.IsNullOrWhiteSpace(newReportingArea))
            {
                throw new AddressMetaArgumentException("Cannot update Address Meta Reporting Area: parameter cannot be null or whitespace.", nameof(newReportingArea));
            }
            else if (newReportingArea.Length > 10)
            {
                throw new AddressMetaArgumentException("Cannot update Address Meta Reporting Area: parameter must be 10 characters or fewer.", nameof(newReportingArea));
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
        /// <exception cref="AddressMetaArgumentException">
        /// Thrown when the latitude paramater is not within the range of -90.0 to 90.0 or the longitude parameter is not within the range of -180.0 to 180.0.
        /// </exception>
        public void UpdateCoordinates(double latitude, double longitude)
        {
            if (latitude > 90.0 || latitude < -90.0)
            {
                throw new AddressMetaArgumentException("Cannot update Address Meta Latitude: parameter must be between -90.0 and 90.0.", nameof(latitude));
            }
            else if (longitude > 180.0 || longitude < -180.0)
            {
                throw new AddressMetaArgumentException("Cannot update Address Meta Latitude: parameter must be between -180.0 and -180.0.", nameof(longitude));
            }
            else
            {
                _latitude = latitude;
                _longitude = longitude;
            }
        }
    }
}
