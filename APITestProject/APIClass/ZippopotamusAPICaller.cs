using Newtonsoft.Json.Linq;
using RestSharp;

namespace APITestProject.APIClass
{
    internal class ZippopotamusAPICaller
    {
        public JToken GetResponseByZip(string country, string zipCode)
        {
            var client = new RestClient("http://api.zippopotam.us/" + country + "/" + zipCode);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);

            JToken parsedJson = JToken.Parse(response.Content);
            return parsedJson;
        }
        public class AddressResponse
        {
            public class Place
            {
                public string? PlaceName { get; set; }
                public string? Longitude { get; set; }
                public string? State { get; set; }
                public string? StateAbbreviation { get; set; }
                public string? Latitude { get; set; }
            }

            public class Root
            {
                public string? PostCode { get; set; }
                public string? Country { get; set; }
                public string? CountryAbbreviation { get; set; }
                public List<Place>? Places { get; set; }
            }

        }
       
    }
}
