using InternShip.Core.Core.Models;
using InternShip.Core.Repository.Interfaces;
using InternShip.Core.Service.Services;
using System.Linq.Expressions;

namespace InternShip.Core.Service.Managers
{
    public class InternBookManager : IInternBookService
    {
        private readonly IInternBookRepository _internBookRepository;

        public InternBookManager(IInternBookRepository internBookRepository)
        {
            _internBookRepository = internBookRepository;
        }

        public async Task ChangeStatusAllAsync(List<InternBook> t)
        {
            await _internBookRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(InternBook t)
        {
            await _internBookRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(List<InternBook> t)
        {
            await _internBookRepository.DeleteAllAsync(t);
        }

        public async Task DeleteAsync(InternBook t)
        {
            await _internBookRepository.DeleteAsync(t);
        }

        public async Task<InternBook> GetByIdAsync(int? id)
        {
            return await _internBookRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(InternBook t)
        {
            await _internBookRepository.InsertAsync(t);
        }

        public async Task<List<InternBook>> ToListAsync()
        {
            return await _internBookRepository.ToListAsync();
        }

        public async Task<List<InternBook>> ToListByFilterAsync(Expression<Func<InternBook, bool>> filter)
        {
            return await _internBookRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(InternBook t)
        {
            await _internBookRepository.UpdateAsync(t);
        }
    }
}
