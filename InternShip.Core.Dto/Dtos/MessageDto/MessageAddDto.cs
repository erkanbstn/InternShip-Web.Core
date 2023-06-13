using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip.Core.Dto.Dtos.MessageDto
{
    public class MessageAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int? LecturerId { get; set; }
        public int? UserId { get; set; }
    }
}
