using InternShip.Core.Core.Models;
using InternShip.Core.Repository.Interfaces;

namespace InternShip.Core.Repository.DataAccess
{
    public class RoleRepository : ModelRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
