using AppSample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSample
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAzureServiceBusService _azureServiceBusService;

        public HomeController(ILogger<HomeController> logger, IAzureServiceBusService azureServiceBusService)
        {
            _logger = logger;
            _azureServiceBusService = azureServiceBusService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
