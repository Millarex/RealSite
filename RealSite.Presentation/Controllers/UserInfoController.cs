using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealSite.Presentation.Identity.User.Commands.UpdateUser;
using RealSite.Presentation.Identity.User.Queries.GetAllUsers;
using RealSite.Presentation.Identity.User.Queries.GetUser;
using RealSite.Presentation.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RealSite.Presentation.Controllers
{
    [Authorize]
    public class UserInfoController : BaseController
    {
        private readonly IMapper _mapper;
        public UserInfoController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var query = new GetAllUserQuery();
            var vm = await Mediator.Send(query);
            if (vm == null)
                return NotFound();
            return View(vm);
        }
        public async Task<IActionResult> Update()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserEmail = currentUser.FindFirst(ClaimTypes.Email).Value;

            var query = new GetUserQuery();
            query.Email = currentUserEmail;
            var vm = await Mediator.Send(query);
            if (vm == null)
                return NotFound();
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserViewModel model)
        {
            var command = _mapper.Map<UpdateUserCommand>(model);
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(command);
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
            model = _mapper.Map<UpdateUserCommand, UpdateUserViewModel>(command);
            return View(model);
        }
    }
}
