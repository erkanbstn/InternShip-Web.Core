namespace InternShip.Core.Dto.Dtos.InternBookDto
{
    public class InternBookAddDto
    {
        public string Description { get; set; }
        public DateTime? InternDay { get; set; }
        public int? UserId { get; set; }
        public int? InternPlaceId { get; set; }
    }
}
