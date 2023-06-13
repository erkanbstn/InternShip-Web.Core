using InternShip.Core.Core.Models;
using InternShip.Core.Repository.Interfaces;
using InternShip.Core.Service.Services;
using System.Linq.Expressions;

namespace InternShip.Core.Service.Managers
{
    public class InternPlaceManager : IInternPlaceService
    {
        private readonly IInternPlaceRepository _internPlaceRepository;

        public InternPlaceManager(IInternPlaceRepository internPlaceRepository)
        {
            _internPlaceRepository = internPlaceRepository;
        }

        public async Task ChangeStatusAllAsync(List<InternPlace> t)
        {
            await _internPlaceRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(InternPlace t)
        {
            await _internPlaceRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(List<InternPlace> t)
        {
            await _internPlaceRepository.DeleteAllAsync(t);
        }

        public async Task DeleteAsync(InternPlace t)
        {
            await _internPlaceRepository.DeleteAsync(t);
        }

        public async Task<InternPlace> GetByIdAsync(int? id)
        {
            return await _internPlaceRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(InternPlace t)
        {
            await _internPlaceRepository.InsertAsync(t);
        }

        public async Task<List<InternPlace>> ToListAsync()
        {
            return await _internPlaceRepository.ToListAsync();
        }

        public async Task<List<InternPlace>> ToListByFilterAsync(Expression<Func<InternPlace, bool>> filter)
        {
            return await _internPlaceRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(InternPlace t)
        {
            await _internPlaceRepository.UpdateAsync(t);
        }
    }
}
