using AutoMapper;
using InternShip.Core.Dto.Dtos.InternBookDto;
using InternShip.Core.Dto.Dtos.InternPlaceDto;
using InternShip.Core.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternShip.Core.UI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize]
    public class InternPlaceController : Controller
    {
        private readonly IInternPlaceService _internPlaceService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IInternBookService _internBookService;
        public InternPlaceController(IInternPlaceService internPlaceService, IMapper mapper, IUserService userService, IInternBookService internBookService)
        {
            _internPlaceService = internPlaceService;
            _mapper = mapper;
            _userService = userService;
            _internBookService = internBookService;
        }

        public async Task<IActionResult> MyInternPlaces()
        {
            var user = await _userService.GetByNoAsync(User.Identity.Name);
            var places = _mapper.Map<List<InternPlaceListDto>>(await _internPlaceService.ToListByFilterAsync(x => x.UserId == user.Id));
            return View(places);
        }
        public async Task<IActionResult> EditInternPlace(int id)
        {
            var internPlace = await _internPlaceService.GetByIdAsync(id);
            return View(new InternPlaceEditDto()
            {
                Id = internPlace.Id,
                EndDate = internPlace.EndDate,
                Place = internPlace.Place,
                StartDate = internPlace.StartDate,
                Status = internPlace.Status,
                UserId = internPlace.UserId
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditInternPlace(InternPlaceEditDto internPlaceEditDto)
        {
            var internPlace = await _internPlaceService.GetByIdAsync(internPlaceEditDto.Id);
            internPlace.Status = internPlaceEditDto.Status;
            if (!internPlace.Status)
            {
                internPlace.EndDate = DateTime.Now;
            }
            internPlace.Place = internPlaceEditDto.Place;
            await _internPlaceService.UpdateAsync(internPlace);
            return Redirect("~/Student/InternPlace/MyInternPlaces");
        }
        public async Task<IActionResult> DetailInternPlace(int id)
        {
            var books = _mapper.Map<List<InternBookListDto>>(await _internBookService.ToListByFilterAsync(x => x.InternPlaceId == id));
            return View(books);
        }
        public IActionResult NewInternPlace()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewInternPlace(InternPlaceAddDto internPlaceAddDto)
        {
            var user = await _userService.GetByNoAsync(User.Identity.Name);
            internPlaceAddDto.UserId = user.Id;
            await _internPlaceService.InsertAsync(new()
            {
                Place = internPlaceAddDto.Place,
                UserId = internPlaceAddDto.UserId,
                StartDate = DateTime.Now,
            });
            return Redirect("~/Student/InternPlace/MyInternPlaces");
        }
    }
}
