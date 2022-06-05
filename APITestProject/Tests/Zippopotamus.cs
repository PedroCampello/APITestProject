using APITestProject.APIClass;
using APITestProject.Helpers;
using Newtonsoft.Json.Linq;

namespace APITestProject.Tests
{
    public class Tests
    {
        internal static ZippopotamusAPICaller zippoAPICaller;

        [SetUp]
        public void Setup()
        {
            zippoAPICaller = new ZippopotamusAPICaller();
        }

        [Test]
        public void ShouldAssertAddressInformation()
        {
            var address = new Address("50120", "United States", "US", "Haverhill", "-92.9829", "Iowa", "IA", "41.9337");
            string callCountry = address.CountryAbbreviation.ToLower();
            string callPostal = address.PostalCode;
            JToken token = zippoAPICaller.GetResponseByZip(callCountry, callPostal);

            string? postalCode = token?.SelectToken("['post code']")?.ToString();
            string? country = token?.SelectToken("country")?.ToString();
            string? countryAbbrev = token?.SelectToken("['country abbreviation']")?.ToString();

            string? placeName = token?.SelectToken("places[0].['place name']")?.ToString();
            string? longitude = token?.SelectToken("places[0].longitude")?.ToString();
            string? state = token?.SelectToken("places[0].state")?.ToString();
            string? stateAbbrev = token?.SelectToken("places[0].['state abbreviation']")?.ToString();
            string? latitude = token?.SelectToken("places[0].latitude")?.ToString();

            Assert.Multiple(() =>
            {
                Assert.That(postalCode, Is.EqualTo(address.PostalCode));
                Assert.That(country, Is.EqualTo(address.Country));
                Assert.That(countryAbbrev, Is.EqualTo(address.CountryAbbreviation));

                Assert.That(placeName, Is.EqualTo(address.PlaceName));
                Assert.That(longitude, Is.EqualTo(address.Longitude));
                Assert.That(state, Is.EqualTo(address.State));
                Assert.That(stateAbbrev, Is.EqualTo(address.StateAbbreviation));
                Assert.That(latitude, Is.EqualTo(address.Latitude));
            });
        }
    }
}