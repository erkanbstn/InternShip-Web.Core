using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip.Core.Dto.Dtos.InternPlaceDto
{
    public class InternPlaceAddDto
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public DateTime? StartDate { get; set; }
        public int? UserId { get; set; }
    }
}
