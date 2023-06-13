using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip.Core.Dto.Dtos.UserDto
{
    public class UserEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string No { get; set; }
        public string Branch { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
    }
}
