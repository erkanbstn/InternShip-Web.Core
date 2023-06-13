using InternShip.Core.Core.Models;

namespace InternShip.Core.Repository.Interfaces
{
    public interface ILecturerRepository : IModelRepository<Lecturer>
    {
        Task<Lecturer> LoginAsync(Lecturer lecturer);
        Task<Lecturer> GetByUserName(string userName);
    }
}
