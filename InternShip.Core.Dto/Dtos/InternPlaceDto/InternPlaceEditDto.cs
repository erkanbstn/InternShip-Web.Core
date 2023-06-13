namespace InternShip.Core.Dto.Dtos.InternPlaceDto
{
    public class InternPlaceEditDto
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public bool Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? UserId { get; set; }
    }
}
