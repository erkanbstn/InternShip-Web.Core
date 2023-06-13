using InternShip.Core.Core.Models;
using InternShip.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternShip.Core.Repository.DataAccess
{
    public class LecturerRepository : ModelRepository<Lecturer>, ILecturerRepository
    {
        private readonly AppDbContext _appDbContext;
        public LecturerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Lecturer> GetByUserName(string userName) => await _appDbContext.Lecturers.FirstOrDefaultAsync(x => x.UserName == userName);
       

        public async Task<Lecturer> LoginAsync(Lecturer lecturer) => await _appDbContext.Lecturers.FirstOrDefaultAsync(x => x.UserName == lecturer.UserName && x.Password == lecturer.Password);

    }
}
