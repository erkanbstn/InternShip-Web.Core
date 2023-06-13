using InternShip.Core.Core.Models;
using System.Security.Claims;

namespace InternShip.Core.Service.Services
{
    public interface ILecturerService : IRepositoryService<Lecturer>
    {
        Task<Lecturer> LoginAsync(Lecturer lecturer);
        Task<Lecturer> GetByUserName(string userName);
        Task<ClaimsPrincipal> SignInWithClaimAsync(Lecturer t);

    }
}
