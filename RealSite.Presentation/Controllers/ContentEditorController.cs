using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RealSite.Presentation.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ContentEditorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
