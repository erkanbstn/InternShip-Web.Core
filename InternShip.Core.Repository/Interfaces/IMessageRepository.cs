using InternShip.Core.Core.Models;

namespace InternShip.Core.Repository.Interfaces
{
    public interface IMessageRepository : IModelRepository<Message>
    {
        Task<List<int?>> GetMessageLecturerById(int userId);
        Task<List<int?>> GetMessageUserById(int lecturerId);
        int GetMessageCountWithLecturer(int? userId,int? lecturerId);
    }
}
