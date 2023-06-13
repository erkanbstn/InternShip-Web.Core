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

        public async Task<List<int?>> GetMessageLecturerById(int userId)
        {
            return await _appDbContext.Messages.Where(x => x.UserId == userId).Select(x => x.LecturerId).Distinct().ToListAsync();
        }
    }
}
