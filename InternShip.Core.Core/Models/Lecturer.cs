namespace InternShip.Core.Core.Models
{
    public class Lecturer : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
