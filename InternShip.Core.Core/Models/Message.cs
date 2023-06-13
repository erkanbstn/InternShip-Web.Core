namespace InternShip.Core.Core.Models
{
    public class Message : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        public int? LecturerId { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
