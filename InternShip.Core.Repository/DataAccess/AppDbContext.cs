using InternShip.Core.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InternShip.Core.Repository.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<InternBook> InternBooks { get; set; }
        public DbSet<InternPlace> InternPlaces { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
