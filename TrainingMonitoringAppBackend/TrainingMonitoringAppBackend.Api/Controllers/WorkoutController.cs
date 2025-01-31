using Microsoft.AspNetCore.Mvc;

namespace TrainingMonitoringAppBackend.Api.Controllers
{
    public class WorkoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
