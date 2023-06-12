using InternShip.Core.Core.Models;
using InternShip.Core.Repository.Interfaces;

namespace InternShip.Core.Repository.DataAccess
{
    public class LecturerRepository : ModelRepository<Lecturer>, ILecturerRepository
    {
        public LecturerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
