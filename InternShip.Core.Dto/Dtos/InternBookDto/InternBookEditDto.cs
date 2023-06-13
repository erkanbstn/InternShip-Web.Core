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
