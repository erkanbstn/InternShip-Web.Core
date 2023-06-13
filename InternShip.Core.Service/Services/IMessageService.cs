using InternShip.Core.Core.Models;

namespace InternShip.Core.Service.Services
{
    public interface IMessageService : IRepositoryService<Message>
    {
        Task<List<int?>> GetMessageLecturerById(int userId);
        int GetMessageCountByLecturer(int? userId, int? lecturerId);
        Task<List<int?>> GetMessageUserById(int lecturerId);

    }
}
