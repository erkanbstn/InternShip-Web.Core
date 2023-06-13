using AutoMapper;
using InternShip.Core.Core.Models;
using InternShip.Core.Dto.Dtos.InternBookDto;
using InternShip.Core.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternShip.Core.UI.Areas.Student.Controllers
{
    [Area("Student")]
    public class InternBookController : Controller
    {
        private readonly IInternBookService _internBookService;
        private readonly IInternPlaceService _internPlaceService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public InternBookController(IInternBookService internBookService, IMapper mapper, IUserService userService, IInternPlaceService internPlaceService)
        {
            _mapper = mapper;
            _userService = userService;
            _internBookService = internBookService;
            _internPlaceService = internPlaceService;
        }

        public async Task<IActionResult> MyInternBooks()
        {
            var user = await _userService.GetByNoAsync(User.Identity.Name);
            var Books = _mapper.Map<List<InternBookListDto>>(await _internBookService.ToListByFilterAsync(x => x.UserId == user.Id));
            return View(Books);
        }
        public async Task<IActionResult> EditInternBook(int id)
        {
            var internBook = await _internBookService.GetByIdAsync(id);
            return View(new InternBookEditDto()
            {
                Id = internBook.Id,
                InternPlace = await _internPlaceService.GetByIdAsync(internBook.InternPlaceId),
                UserId = internBook.UserId,
                Description = internBook.Description,
                InternDay = internBook.InternDay,
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditInternBook(InternBookEditDto internBookEditDto)
        {
            var internBook = await _internBookService.GetByIdAsync(internBookEditDto.Id);
            internBook.Id = internBookEditDto.Id;
            internBook.InternPlaceId = internBookEditDto.InternPlaceId;
            internBook.Description = internBookEditDto.Description;
            internBook.InternDay = internBookEditDto.InternDay;
            await _internBookService.UpdateAsync(internBook);
            return Redirect("~/Student/InternBook/MyInternBooks");
        }
        public IActionResult NewInternBook()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewInternBook(InternBookAddDto internBookAddDto)
        {
            var user = await _userService.GetByNoAsync(User.Identity.Name);
            internBookAddDto.UserId = user.Id;
            await _internBookService.InsertAsync(new()
            {
                UserId = internBookAddDto.UserId,
                InternPlaceId = internBookAddDto.InternPlaceId,
                Description = internBookAddDto.Description,
                InternDay = internBookAddDto.InternDay,
            });
            return Redirect("~/Student/InternBook/MyInternBooks");
        }
    }
}
