using InternShip.Core.Dto.Dtos.LecturerDto;
using InternShip.Core.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternShip.Core.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILecturerService _lecturerService;

        public UserController(ILecturerService lecturerService)
        {
            _lecturerService = lecturerService;
        }

        public async Task<IActionResult> MyProfile()
        {
            var lecturer = await _lecturerService.GetByUserName(User.Identity.Name);
            return View(new LecturerEditDto()
            {
                Id = lecturer.Id,
                Name = lecturer.Name,
                Surname = lecturer.Surname,
                Password = lecturer.Password,
                UserName = lecturer.UserName,
            });
        }
        [HttpPost]
        public async Task<IActionResult> MyProfile(LecturerEditDto lecturerEditDto)
        {
            var lecturer = await _lecturerService.GetByUserName(User.Identity.Name);
            lecturer.Name = lecturerEditDto.Name;
            lecturer.Surname = lecturerEditDto.Surname;
            lecturer.Password = lecturerEditDto.Password;
            await _lecturerService.UpdateAsync(lecturer);
            TempData["Success"] = "Your Profile Information Has Been Successfully Updated.";
            return View();
        }
    }
}
