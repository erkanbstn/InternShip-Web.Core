using InternShip.Core.Core.Models;

namespace InternShip.Core.Service.Services
{
    public interface IInternPlaceService : IRepositoryService<InternPlace>
    {
        Task<InternPlace> GetByIdAsync(int? internPlaceId);
    }
}
