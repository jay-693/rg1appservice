using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;

namespace rg1appservice.Controllers
{
    public class TelemetryDemoController : Controller
    {
        private readonly TelemetryClient _telemetryClient;

        public TelemetryDemoController(TelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }

        public IActionResult TrackCustomEvent()
        {
            var properties = new Dictionary<string, string>
            {
                { "UserId", "12345" },
                { "Feature", "CustomEvent" }
            };

            var metrics = new Dictionary<string, double>
            {
                { "ExecutionTime", 500 }
            };

            _telemetryClient.TrackEvent("CustomEventWithProperties", properties, metrics);

            return Ok("Custom event tracked successfully");
        }
    }
}
