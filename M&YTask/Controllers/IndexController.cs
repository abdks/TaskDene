using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using M_YTask.Model;

namespace M_YTask.Controllers
{
    public class IndexController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=USD&to=EUR&amount=750"),
                Headers =
                {
                    { "X-RapidAPI-Key", "7716aa210cmsh52c76252642d8a7p1e643ejsn86b396b3d32c" },
                    { "X-RapidAPI-Host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Dollar>>(body);
                return View(values);
            }
        }
    }
}
