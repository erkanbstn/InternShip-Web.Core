namespace InternShip.Core.Core.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Lecturer> Lecturers { get; set; }

    }
}
