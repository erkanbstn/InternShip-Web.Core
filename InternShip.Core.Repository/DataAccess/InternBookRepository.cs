using InternShip.Core.Core.Models;
using InternShip.Core.Repository.Interfaces;

namespace InternShip.Core.Repository.DataAccess
{
    public class InternBookRepository : ModelRepository<InternBook>, IInternBookRepository
    {
        public InternBookRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
