using APITestProject.APIClass;
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
            string countryEntry = "us";
            string postalEntry = "50120";
            JToken token = zippoAPICaller.GetResponseByZip(countryEntry, postalEntry);

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
                Assert.That(postalCode, Is.EqualTo("50120"));
                Assert.That(country, Is.EqualTo("United States"));
                Assert.That(countryAbbrev, Is.EqualTo("us".ToUpper()));

                Assert.That(placeName, Is.EqualTo("Haverhill"));
                Assert.That(longitude, Is.EqualTo("-92.9829"));
                Assert.That(state, Is.EqualTo("Iowa"));
                Assert.That(stateAbbrev, Is.EqualTo("IA"));
                Assert.That(latitude, Is.EqualTo("41.9337"));
            });
        }
    }
}