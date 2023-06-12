using InternShip.Core.Core.Models;
using InternShip.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternShip.Core.Repository.DataAccess
{
    public class UserRepository : ModelRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<User> GetByNoAsync(string no)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.No == no);
        }

        public async Task<User> LoginAsync(User user) => await _context.Users.FirstOrDefaultAsync(x => x.No == user.No && x.Password == user.Password);
    }
}
