using InternShip.Core.Core.Models;
using InternShip.Core.Repository.Interfaces;
using InternShip.Core.Service.Services;
using System.Linq.Expressions;

namespace InternShip.Core.Service.Managers
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageManager(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task ChangeStatusAllAsync(List<Message> t)
        {
            await _messageRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(Message t)
        {
            await _messageRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(List<Message> t)
        {
            await _messageRepository.DeleteAllAsync(t);
        }

        public async Task DeleteAsync(Message t)
        {
            await _messageRepository.DeleteAsync(t);
        }

        public async Task<Message> GetByIdAsync(int? id)
        {
            return await _messageRepository.GetByIdAsync(id);
        }

        public async Task<List<int?>> GetMessageLecturerById(int userId)
        {
            return await _messageRepository.GetMessageLecturerById(userId);
        }

        public async Task InsertAsync(Message t)
        {
            await _messageRepository.InsertAsync(t);
        }

        public async Task<List<Message>> ToListAsync()
        {
            return await _messageRepository.ToListAsync();
        }

        public async Task<List<Message>> ToListByFilterAsync(Expression<Func<Message, bool>> filter)
        {
            return await _messageRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(Message t)
        {
            await _messageRepository.UpdateAsync(t);
        }
    }
}