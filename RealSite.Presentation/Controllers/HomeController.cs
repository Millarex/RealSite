using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealSite.Domain;
using RealSite.Presentation.Services;
using RealSite.Presentation.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RealSite.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageSender _emailService;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public HomeController(IMessageSender emailService,
            UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _emailService = emailService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index() => View();
        public IActionResult About() => View();

        [HttpGet]
        public async Task<IActionResult> ServiceRequest()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                return View(new ServiceRequestViewModel
                {
                    Email = user.Email,
                    Phone = user.Phone,
                    Organization = user.Organization,
                    ContactPerson = user.ContactPerson
                });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ServiceRequest(ServiceRequestViewModel model, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadedFile != null)
                {
                    await _emailService.SendEmailAsync("Belikaleksei@gmail.com", "New Service Request",
                        $"User for organization: {model.Organization} " +
                        $"left a request: {model.RequestType}: {model.Description}  " +
                        $"Contact data: {model.ContactPerson},{model.Phone}", uploadedFile);
                }
                else
                {
                    await _emailService.SendEmailAsync("Belikaleksei@gmail.com", "New Service Request",
                    $"User for organization: {model.Organization} " +
                    $"Left a request: {model.RequestType}: {model.Description}  " +
                    $"Contact data: {model.ContactPerson},{model.Phone}");
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
