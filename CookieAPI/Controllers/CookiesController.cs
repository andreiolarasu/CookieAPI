using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CookieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookiesController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public CookiesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpOptions]
        public void OptionsMethod()
        {
            Response.StatusCode = 200;
            Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)Request.Headers["Origin"] });
            Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept" });
            Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
            Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
        }

        [HttpPost]
        public async Task AddPreferencesFromJsonAsync()
        {
            string data;
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                data = await reader.ReadToEndAsync();
            }

            var preferences = JsonConvert.DeserializeObject<dynamic>(data);

            preferences.Id = Guid.NewGuid();
            preferences.Created = DateTime.Now;

            var path = _hostingEnvironment.ContentRootPath;
            System.IO.File.AppendAllText($"{path}/survey/survey.json", JsonConvert.SerializeObject(preferences) + "," + Environment.NewLine);

            Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)Request.Headers["Origin"] });
            Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept" });
            Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
            Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
            Response.StatusCode = 200;

        }
    }
}
