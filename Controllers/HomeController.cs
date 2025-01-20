namespace rg1appservice.Controllers
{
    using Microsoft.ApplicationInsights;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    namespace CustomTelemetryApp.Controllers
    {
        public class HomeController : Controller
        {
            private readonly TelemetryClient _telemetryClient;

            public HomeController(TelemetryClient telemetryClient)
            {
                _telemetryClient = telemetryClient;
            }

            public IActionResult Index()
            {
                // Log a custom event
                _telemetryClient.TrackEvent("HomePageLoaded");

                // Log a custom metric
                _telemetryClient.GetMetric("Traffic count").TrackValue(123);

                // Log custom trace
                _telemetryClient.TrackTrace("HomeController.Index accessed");

                return View();
            }

            public IActionResult Error()
            {
                try
                {
                    throw new Exception("Sample exception");
                }
                catch (Exception ex)
                {
                    // Capture exception telemetry with custom properties
                    var properties = new Dictionary<string, string>
                {
                    { "Controller", "Home" },
                    { "Action", "Error" }
                };

                    _telemetryClient.TrackException(ex, properties);

                    return View("Error");
                }
            }
        }
    }
}
