using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedisCacheWebAP.Models;
using ServiceStack.Caching;

namespace RedisCacheWebAP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICacheClient _cacheClient;

        public HomeController(ILogger<HomeController> logger, ICacheClient cacheClient)
        {
            _logger = logger;
            _cacheClient = cacheClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult TestCache()
        {
            DateTime? dt = _cacheClient.Get<DateTime?>("time");
            if (dt == null)
            {
                dt = DateTime.Now;
                _cacheClient.Set<DateTime?>("time", dt.Value, TimeSpan.FromMinutes(1));
            }

            return Content(dt.Value.ToString());
        }
    }
}
