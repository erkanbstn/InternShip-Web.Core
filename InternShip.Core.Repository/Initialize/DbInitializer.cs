using InternShip.Core.Repository.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip.Core.Repository.Initialize
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;

        public DbInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void Run()
        {
            if (!(_context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            {
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();
                _context.Lecturers.Add(new()
                {
                    Name = "Admin",
                    Surname = "Lecturer",
                    Password = "123",
                    UserName = "admin"
                });
                _context.SaveChanges();
            }
        }
    }
}
