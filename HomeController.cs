
using Microsoft.AspNetCore.Mvc;
using JusticeSecSensitivityChecker.Services;
using System.Collections.Generic;

namespace JusticeSecSensitivityChecker.Controllers
{
    public class HomeController : Controller
    {
        private readonly SensitivityDetectionService _sensitivityService = new();

        [HttpGet]
        public IActionResult Analyze() => View();

        [HttpPost]
        public IActionResult Analyze(Dictionary<string, string> fields)
        {
            var results = _sensitivityService.AnalyzeFields(fields);
            return View("Results", results);
        }
    }
}
