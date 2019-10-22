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

        }
    }
}
