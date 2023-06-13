namespace InternShip.Core.Dto.Dtos.MessageDto
{
    public class MessageListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; }
        public int? LecturerId { get; set; }
        public int? UserId { get; set; }
    }
}
