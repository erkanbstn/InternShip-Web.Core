using InternShip.Core.Core.Models;
using InternShip.Core.Repository.Interfaces;
using InternShip.Core.Service.Services;
using System.Linq.Expressions;

namespace InternShip.Core.Service.Managers
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleManager(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task ChangeStatusAllAsync(List<Role> t)
        {
            await _roleRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(Role t)
        {
            await _roleRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(List<Role> t)
        {
            await _roleRepository.DeleteAllAsync(t);
        }

        public async Task DeleteAsync(Role t)
        {
            await _roleRepository.DeleteAsync(t);
        }

        public async Task<Role> GetByIdAsync(int? id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Role t)
        {
            await _roleRepository.InsertAsync(t);
        }

        public async Task<List<Role>> ToListAsync()
        {
            return await _roleRepository.ToListAsync();
        }

        public async Task<List<Role>> ToListByFilterAsync(Expression<Func<Role, bool>> filter)
        {
            return await _roleRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(Role t)
        {
            await _roleRepository.UpdateAsync(t);
        }
    }
}
