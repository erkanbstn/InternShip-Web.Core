namespace InternShip.Core.Core.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string No { get; set; }
        public string Branch { get; set; }
        public string Password { get; set; }
        public ICollection<InternBook> InternBooks { get; set; }
        public ICollection<InternPlace> InternShips { get; set; }
    }
}
