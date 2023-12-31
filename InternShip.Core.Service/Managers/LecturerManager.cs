﻿using InternShip.Core.Core.Models;
using InternShip.Core.Repository.Interfaces;
using InternShip.Core.Service.Services;
using System.Linq.Expressions;
using System.Security.Claims;

namespace InternShip.Core.Service.Managers
{
    public class LecturerManager : ILecturerService
    {
        private readonly ILecturerRepository _lecturerRepository;

        public LecturerManager(ILecturerRepository lecturerRepository)
        {
            _lecturerRepository = lecturerRepository;
        }

        public async Task ChangeStatusAllAsync(List<Lecturer> t)
        {
            await _lecturerRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(Lecturer t)
        {
            await _lecturerRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(List<Lecturer> t)
        {
            await _lecturerRepository.DeleteAllAsync(t);
        }

        public async Task DeleteAsync(Lecturer t)
        {
            await _lecturerRepository.DeleteAsync(t);
        }

        public async Task<Lecturer> GetByIdAsync(int? id)
        {
            return await _lecturerRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Lecturer t)
        {
            await _lecturerRepository.InsertAsync(t);
        }
        public async Task<ClaimsPrincipal> SignInWithClaimAsync(Lecturer t)
        {
            var user = await LoginAsync(t);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };
            var userIdentity = new ClaimsIdentity(claims, "SignInLecturer");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
            //HttpContext.Session.SetString("UserMail", x.WriterMail);
            return claimsPrincipal;
        }
        public async Task<Lecturer> LoginAsync(Lecturer lecturer)
        {
            return await _lecturerRepository.LoginAsync(lecturer);
        }

        public async Task<List<Lecturer>> ToListAsync()
        {
            return await _lecturerRepository.ToListAsync();
        }

        public async Task<List<Lecturer>> ToListByFilterAsync(Expression<Func<Lecturer, bool>> filter)
        {
            return await _lecturerRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(Lecturer t)
        {
            await _lecturerRepository.UpdateAsync(t);
        }

        public async Task<Lecturer> GetByUserName(string userName)
        {
            return await _lecturerRepository.GetByUserName(userName);
        }
    }
}
