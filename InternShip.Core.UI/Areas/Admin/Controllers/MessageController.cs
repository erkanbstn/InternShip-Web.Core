using AutoMapper;
using InternShip.Core.Dto.Dtos.MessageDto;
using InternShip.Core.Repository.DataAccess;
using InternShip.Core.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternShip.Core.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MessageController : Controller
    {
        private readonly ILecturerService _lecturerService;
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public MessageController(IMessageService messageService, ILecturerService lecturerService, IUserService userService, IMapper mapper)
        {
            _messageService = messageService;
            _lecturerService = lecturerService;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IActionResult> MyInbox()
        {
            List<MessageUserListDto> messageUserListDto = new List<MessageUserListDto>();
            var lecturer = await _lecturerService.GetByUserName(User.Identity.Name);
            var users = await _messageService.GetMessageUserById(lecturer.Id);
            foreach (var item in users)
            {
                var user = await _userService.GetByIdAsync(item);
                messageUserListDto.Add(new MessageUserListDto()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Id = user.Id,
                    Count = _messageService.GetMessageCountByLecturer(item, lecturer.Id),
                });
            }
            return View(messageUserListDto);
        }
        public async Task<IActionResult> NewMessage(int id)
        {
            if (id > 0)
            {
                var user = await _userService.GetByIdAsync(id);
                ViewBag.User = $"{user.Name} {user.Surname}";
                return View(new MessageAddDto()
                {
                    UserId = user.Id,
                });
            }
            ViewBag.users = (from c in await _userService.ToListAsync() select new SelectListItem { Text = $"{c.Name} {c.Surname}", Value = c.Id.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewMessage(MessageAddDto messageAddDto)
        {
            var lecturer = await _lecturerService.GetByUserName(User.Identity.Name);
            await _messageService.InsertAsync(new()
            {
                Content = messageAddDto.Content,
                Title = messageAddDto.Title,
                LecturerId = lecturer.Id,
                UserId = messageAddDto.UserId
            });
            return Redirect("~/Admin/Message/MyInbox");
        }
        public async Task<IActionResult> DetailMessages(int id)
        {
            var lecturer = await _lecturerService.GetByUserName(User.Identity.Name);
            var messages = _mapper.Map<List<MessageListDto>>(await _messageService.ToListByFilterAsync(x => x.UserId == id && x.LecturerId == lecturer.Id));
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
            return Redirect("~/Admin/Message/MyInbox");
        }
    }
}
