using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealSite.Domain;
using RealSite.Presentation.Identity.Roles.Commands.CreateRole;
using RealSite.Presentation.Identity.Roles.Commands.DeleteRole;
using RealSite.Presentation.Identity.Roles.Queries.GetAllRoles;
using RealSite.Presentation.Identity.Roles.Queries.GetAllUserRole;
using RealSite.Presentation.Identity.User.Commands.CreateUser;
using RealSite.Presentation.Identity.User.Commands.DeleteUser;
using RealSite.Presentation.Identity.User.Commands.UpdateUser;
using RealSite.Presentation.Identity.User.Commands.UpdateUserRole;
using RealSite.Presentation.Identity.User.Queries.GetAllUsers;
using RealSite.Presentation.Identity.User.Queries.GetUser;
using RealSite.Presentation.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealSite.Presentation.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserManagmentController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly UserManager<UserModel> _userManager;

        public UserManagmentController(UserManager<UserModel> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        #region User Editor
        public async Task<IActionResult> Index()
        {
            var query = new GetAllUserQuery();
            var vm = await Mediator.Send(query);
            if (vm == null)
                return NotFound();
            return View(vm);
        }

        public IActionResult CreateUser() => View();
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            var command = _mapper.Map<CreateUserCommand>(model);
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(command);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    await _userManager.ConfirmEmailAsync(user, code);
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
            model = _mapper.Map<CreateUserCommand, CreateUserViewModel>(command);
            return View(model);
        }

        public async Task<IActionResult> UpdateUser(string id)
        {
            var query = new GetUserQuery();
            query.Id = id;
            var vm = await Mediator.Send(query);
            if (vm == null)
                return NotFound();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel model)
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

        [HttpPost]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var command = new DeleteUserCommand();
            command.Id = id;
            if (await Mediator.Send(command))
                return RedirectToAction("Index");
            return NotFound();
        }

        #endregion

        #region Role Editor
        public async Task<IActionResult> GetRolesList()
        {
            var query = new GetAllRolesQuery();
            var vm = await Mediator.Send(query);
            if (vm == null)
                return NotFound();
            return View("RoleList", vm);
        }

        public IActionResult CreateRole() => View();

        [HttpPost]
        public async Task<IActionResult> CreateRole(string name)
        {
            var command = new CreateRoleCommand();
            command.Name = name;
            if (await Mediator.Send(command))
                return RedirectToAction("GetRolesList");
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var command = new DeleteRoleCommand();
            command.Id = id;
            if (await Mediator.Send(command))
                return RedirectToAction("GetRolesList");
            return NotFound();
        }

        public async Task<IActionResult> UpdateUserRole(string userId)
        {
            var query = new GetAllUserRoleQuery();
            query.UserId = userId;
            var vm = await Mediator.Send(query);
            if (vm == null)
                return NotFound();
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUserRole(string userId, List<string> roles)
        {
            var command = new UpdateUserRoleCommand
            {
                UserId = userId,
                Roles = roles
            };

            if (await Mediator.Send(command))
                return RedirectToAction("UpdateUserRole");
            return NotFound();
        }

        #endregion
    }
}
