using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestProject.Helpers
{
    public class Address
    {
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string CountryAbbreviation { get; set; }
        public string PlaceName { get; set; }
        public string Longitude { get; set; }
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
        public string Latitude { get; set; }

        public Address(string postalCode, string country, string countryAbbreviation, string placeName, string longitude, string state, string stateAbbreviation, string latitude)
        {
            this.PostalCode = postalCode.ToString();
            this.Country = country.ToString();
            this.CountryAbbreviation = countryAbbreviation.ToString();
            this.PlaceName = placeName.ToString();
            this.Longitude = longitude.ToString();
            this.State = state.ToString();
            this.StateAbbreviation = stateAbbreviation.ToString();
            this.Latitude = latitude.ToString();
        }
    }
}
