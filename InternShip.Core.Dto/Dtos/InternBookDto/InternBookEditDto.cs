using InternShip.Core.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip.Core.Dto.Dtos.InternBookDto
{
    public class InternBookEditDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? InternDay { get; set; }
        public int? UserId { get; set; }
        public int? InternPlaceId { get; set; }
    }
}
