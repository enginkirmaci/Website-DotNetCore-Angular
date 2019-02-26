using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Website.SPA;

namespace Website.Tests.Website.SPA
{
    [TestClass]
    public class MainControllerIntegrationTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public MainControllerIntegrationTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            _client = _server.CreateClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [TestMethod]
        public async Task Default_Get_Model()
        {
            //// Act
            //var response = await _client.GetAsync("/api/Main/Default");

            //response.EnsureSuccessStatusCode();
            //var responseString = await response.Content.ReadAsStringAsync();
            //var model = JsonConvert.DeserializeObject<MainViewModel>(responseString);

            //// Assert
            //model.Menu.Should().NotBeNull();
            //model.Settings.Should().NotBeEmpty();
        }
    }
}