using InternShip.Core.Core.Models;
using InternShip.Core.Dto.Dtos.UserDto;
using InternShip.Core.Service.Services;
using InternShip.Core.UI.Areas.Student.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternShip.Core.UI.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterDto userRegisterDto)
        {
            await _userService.InsertAsync(new()
            {
                Branch = userRegisterDto.Branch,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
                Password = userRegisterDto.Password,
                RoleId = 2
            });
            return RedirectToAction(nameof(SignIn));
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            var user = await _userService.LoginAsync(new()
            {
                No = userLoginDto.No,
                Password = userLoginDto.Password
            });
            if (user == null)
            {
                ViewBag.failure = "No or Password Incorrect!";
                return View();
            }
            await HttpContext.SignInAsync(await _userService.SignInWithClaimAsync(user));
            return Redirect("~/Student/Intern/MyInternPlaces");
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
    }
}
