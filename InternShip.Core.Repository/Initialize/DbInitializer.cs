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
            if(!(_context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            {
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();
                _context.Roles.Add(new()
                {
                    Name = "Lecturer"
                });
                _context.Roles.Add(new()
                {
                    Name = "Student"
                });
                _context.SaveChanges();
                _context.Lecturers.Add(new()
                {
                    Name = "Test Lecturer",
                    Surname= "Test Lecturer",
                    RoleId=1,
                });
                _context.SaveChanges();
            }
        }
    }
}
