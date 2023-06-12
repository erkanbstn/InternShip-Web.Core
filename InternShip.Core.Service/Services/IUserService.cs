using InternShip.Core.Core.Models;
using System.Security.Claims;

namespace InternShip.Core.Service.Services
{
    public interface IUserService : IRepositoryService<User>
    {
        Task<User> LoginAsync(User user);
        Task<ClaimsPrincipal> SignInWithClaimAsync(User t);
        Task<User> GetByNoAsync(string no);
    }
}
