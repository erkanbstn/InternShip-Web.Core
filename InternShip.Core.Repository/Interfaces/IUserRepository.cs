using InternShip.Core.Core.Models;

namespace InternShip.Core.Repository.Interfaces
{
    public interface IUserRepository : IModelRepository<User>
    {
        Task<User> LoginAsync(User user);
        Task<User> GetByNoAsync(string no);
    }
}
