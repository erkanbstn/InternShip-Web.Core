using AutoMapper;
using InternShip.Core.Dto.Dtos.InternBookDto;
using InternShip.Core.Dto.Dtos.InternPlaceDto;
using InternShip.Core.Dto.Dtos.UserDto;
using InternShip.Core.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternShip.Core.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class InternController : Controller
    {
        private readonly IUserService _userService;
        private readonly IInternPlaceService _internPlaceService;
        private readonly IInternBookService _internBookService;
        private readonly IMapper _mapper;
        public InternController(IUserService userService, IMapper mapper, IInternPlaceService internPlaceService, IInternBookService internBookService)
        {
            _userService = userService;
            _mapper = mapper;
            _internPlaceService = internPlaceService;
            _internBookService = internBookService;
        }

        public async Task<IActionResult> InternShip()
        {
            var interns = _mapper.Map<List<UserListDto>>(await _userService.ToListAsync());
            return View(interns);
        }
        public async Task<IActionResult> InternPlaceDetail(int id)
        {
            var internPlaces = _mapper.Map<List<InternPlaceListDto>>(await _internPlaceService.ToListByFilterAsync(x => x.UserId == id));
            return View(internPlaces);
        }
        public async Task<IActionResult> InternBookDetail(int id)
        {
            var internBook = _mapper.Map<List<InternBookListDto>>(await _internBookService.ToListByFilterAsync(x => x.InternPlaceId == id && x.UserId == 1));
            return View(internBook);
        }
    }
}
