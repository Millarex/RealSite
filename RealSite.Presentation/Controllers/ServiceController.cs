using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace RealSite.Presentation.Controllers
{
    public class ServiceController : Controller
    {
        [Authorize(Roles = "Administrator,Moderator")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

    }
}
