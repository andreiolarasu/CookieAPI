using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CookieAPI.Models;

namespace CookieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookiesController : ControllerBase
    {
        [HttpPost]
        public void AddPreferences(CookiePreferencesModel data)
        {
            var preferences = data;

            preferences.Id = Guid.NewGuid();
            preferences.Created = DateTime.Now;

            DAL.DAL.AddCookiePreferences(preferences);

        }
    }
}
