namespace InternShip.Core.Core.Models
{
    public class InternPlace : BaseModel
    {
        public string Place { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<InternBook> InternBooks { get; set; }
    }
}
