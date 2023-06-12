namespace InternShip.Core.Core.Models
{
    public class InternBook : BaseModel
    {
        public string Description { get; set; }
        public DateTime? InternDay { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? InternPlaceId { get; set; }
        public virtual InternPlace InternPlace { get; set; }
    }
}
