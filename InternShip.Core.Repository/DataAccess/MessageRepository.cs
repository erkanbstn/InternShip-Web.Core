using InternShip.Core.Core.Models;
using InternShip.Core.Repository.Interfaces;

namespace InternShip.Core.Repository.DataAccess
{
    public class MessageRepository : ModelRepository<Message>, IMessageRepository
    {
        public MessageRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
