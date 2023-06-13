using AutoMapper;
using InternShip.Core.Dto.Dtos.MessageDto;
using InternShip.Core.Repository.DataAccess;
using InternShip.Core.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternShip.Core.UI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize]
    public class MessageController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        private readonly ILecturerService _lecturerService;
        private readonly IMapper _mapper;
        public MessageController(AppDbContext appDbContext, IUserService userService, IMessageService messageService, ILecturerService lecturerService, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _userService = userService;
            _messageService = messageService;
            _lecturerService = lecturerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> MyInbox()
        {
            List<MessageLecturerListDto> messageLecturerListDtos = new List<MessageLecturerListDto>();
            var user = await _userService.GetByNoAsync(User.Identity.Name);
            var lecturers = await _messageService.GetMessageLecturerById(user.Id);
            foreach (var item in lecturers)
            {
                var lecturer = await _lecturerService.GetByIdAsync(item);
                messageLecturerListDtos.Add(new MessageLecturerListDto()
                {
                    Name = lecturer.Name,
                    Surname = lecturer.Surname,
                    Id = lecturer.Id,
                    Count = _messageService.GetMessageCountByLecturer(user.Id, item)
                });
            }
            return View(messageLecturerListDtos);
        }
        public async Task<IActionResult> NewMessage(int id)
        {
            if (id > 0)
            {
                var lecturer = await _lecturerService.GetByIdAsync(id);
                ViewBag.Lecturer = $"{lecturer.Name} {lecturer.Surname}";
                return View(new MessageAddDto()
                {
                    LecturerId = lecturer.Id,
                });
            }
            ViewBag.lecturers = (from c in await _lecturerService.ToListAsync() select new SelectListItem { Text = $"{c.Name} {c.Surname}", Value = c.Id.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewMessage(MessageAddDto messageAddDto)
        {
            var user = await _userService.GetByNoAsync(User.Identity.Name);
            await _messageService.InsertAsync(new()
            {
                Content = messageAddDto.Content,
                Title = messageAddDto.Title,
                LecturerId = messageAddDto.LecturerId,
                UserId = user.Id
            });
            return Redirect("~/Student/Message/MyInbox");
        }
        public async Task<IActionResult> DetailMessages(int id)
        {
            var user = await _userService.GetByNoAsync(User.Identity.Name);
            var messages = _mapper.Map<List<MessageListDto>>(await _messageService.ToListByFilterAsync(x => x.UserId == user.Id && x.LecturerId == id));
            return View(messages);
        }
        public async Task<IActionResult> DetailMessage(int id)
        {
            var message = await _messageService.GetByIdAsync(id);
            return View(new MessageListDto()
            {
                Content = message.Content,
                Date = message.Date,
                Id = message.Id,
                LecturerId = message.LecturerId,
                Title = message.Title,
                UserId = message.UserId
            });
        }
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _messageService.DeleteAsync(await _messageService.GetByIdAsync(id));
            return Redirect("~/Student/Message/MyInbox");
        }
    }
}
