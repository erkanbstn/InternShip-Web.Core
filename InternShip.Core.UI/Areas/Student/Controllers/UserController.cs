using InternShip.Core.Dto.Dtos.UserDto;
using InternShip.Core.Service.Managers;
using InternShip.Core.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternShip.Core.UI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> MyProfile()
        {
            var user = await _userService.GetByNoAsync(User.Identity.Name);
            return View(new UserEditDto()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Branch = user.Branch,
                Email = user.Email,
                No = user.No,
                Password = user.Password
            });
        }
        [HttpPost]
        public async Task<IActionResult> MyProfile(UserEditDto userEditDto)
        {
            var user = await _userService.GetByNoAsync(User.Identity.Name);
            user.Name = userEditDto.Name;
            user.Surname = userEditDto.Surname;
            user.Email = userEditDto.Email;
            user.No = userEditDto.No;
            user.Password = userEditDto.Password;
            await _userService.UpdateAsync(user);
            TempData["Success"] = "Your Profile Information Has Been Successfully Updated.";
            return View();
        }
    }
}
