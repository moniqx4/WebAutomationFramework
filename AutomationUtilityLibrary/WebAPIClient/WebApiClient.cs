using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AutomationUtilityLibrary.WebAPIClient
{
    public class WebApiClient
    {
        private static readonly HttpClient client = new HttpClient();

        public WebApiClient()
        {

        }

        static void Main(string[] args)
        {
            ProcessApiData().Wait();
        }

        private static async Task<List<TestConfigurationData>> ProcessApiData()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<TestConfigurationData>));

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var testConfigurationDatas = serializer.ReadObject(await streamTask) as List<TestConfigurationData>;
            return testConfigurationDatas;
        }
    }
}
