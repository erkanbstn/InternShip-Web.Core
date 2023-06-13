using InternShip.Core.Core.Models;
using InternShip.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternShip.Core.Repository.DataAccess
{
    public class MessageRepository : ModelRepository<Message>, IMessageRepository
    {
        private readonly AppDbContext _appDbContext;
        public MessageRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int GetMessageCountWithLecturer(int? userId, int? lecturerId) => _appDbContext.Messages.Where(x => x.UserId == userId && x.LecturerId == lecturerId).Count();

        public async Task<List<int?>> GetMessageLecturerById(int userId) => await _appDbContext.Messages.Where(x => x.UserId == userId).Select(x => x.LecturerId).Distinct().ToListAsync();
        public async Task<List<int?>> GetMessageUserById(int lecturerId) => await _appDbContext.Messages.Where(x => x.LecturerId == lecturerId).Select(x => x.UserId).Distinct().ToListAsync();
    }
}
