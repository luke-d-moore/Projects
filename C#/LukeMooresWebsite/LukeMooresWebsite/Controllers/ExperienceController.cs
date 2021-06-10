using LukeMooresWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LukeMooresWebsite.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly ILogger<ExperienceController> _logger;

        public ExperienceController(ILogger<ExperienceController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var experience = new ExperienceModel();
            return View(experience);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
