using InternShip.Core.Core.Models;
using InternShip.Core.Repository.Interfaces;
using InternShip.Core.Service.Services;
using System.Linq.Expressions;
using System.Security.Claims;

namespace InternShip.Core.Service.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly Random _random;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _random = new Random();
        }

        public async Task ChangeStatusAllAsync(List<User> t)
        {
            await _userRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(User t)
        {
            await _userRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(List<User> t)
        {
            await _userRepository.DeleteAllAsync(t);
        }

        public async Task DeleteAsync(User t)
        {
            await _userRepository.DeleteAsync(t);
        }

        public async Task<User> GetByIdAsync(int? id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(User t)
        {
            t.No = _random.Next(0, 999999999).ToString();
            await _userRepository.InsertAsync(t);
        }
        public async Task<ClaimsPrincipal> SignInWithClaimAsync(User t)
        {
            var user = await LoginAsync(t);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.No) };
            var userIdentity = new ClaimsIdentity(claims, "SignIn");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
            //HttpContext.Session.SetString("UserMail", x.WriterMail);
            return claimsPrincipal;
        }
        public async Task<User> LoginAsync(User user)
        {
            return await _userRepository.LoginAsync(user);
        }

        public async Task<List<User>> ToListAsync()
        {
            return await _userRepository.ToListAsync();
        }

        public async Task<List<User>> ToListByFilterAsync(Expression<Func<User, bool>> filter)
        {
            return await _userRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(User t)
        {
            await _userRepository.UpdateAsync(t);
        }

        public async Task<User> GetByNoAsync(string no)
        {
            return await _userRepository.GetByNoAsync(no);
        }
    }
}
