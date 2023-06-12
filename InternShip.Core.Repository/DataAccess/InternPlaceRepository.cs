using InternShip.Core.Core.Models;
using InternShip.Core.Repository.Interfaces;

namespace InternShip.Core.Repository.DataAccess
{
    public class InternPlaceRepository : ModelRepository<InternPlace>, IInternPlaceRepository
    {
        public InternPlaceRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
