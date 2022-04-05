using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealSite.Presentation.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace RealSite.Presentation.Controllers
{
    [Authorize]
    public class UserInfoController : Controller
    {
        UserManager<UserModel> _userManager;

        public UserInfoController(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index() => View(await _userManager.GetUserAsync(User));
        public async Task<IActionResult> Edit()
        {
            UserModel user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Email = user.Email, Organization = user.Organization, ContactPerson = user.ContactPerson, Phone = user.Phone };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.Organization = model.Organization;
                    user.ContactPerson = model.ContactPerson;
                    user.Phone = model.Phone;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> ChangePassword()
        {
            UserModel user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    IdentityResult result =
                        await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found");
                }
            }
            return View(model);
        }
    }
}
