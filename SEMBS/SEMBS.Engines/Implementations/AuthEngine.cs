using Microsoft.AspNetCore.Identity;
using SEMBS.SEMBS.Engines.Contracts;
using SEMBS.SEMBS.Models.DTO;
using SEMBS.SEMBS.Models.Entities;
using SEMBS.SEMBS.Repository.Contracts;

namespace SEMBS.SEMBS.Engines.Implementations
{
    public class AuthEngine : IAuthEngine
    {
        private IGenericRepository<User> _userRepo;
        private IGenericRepository<Role> _roleRepo;
        public static bool Verify(string password, string passwordHash) => BCrypt.Net.BCrypt.Verify(password, passwordHash);

        public AuthEngine(IGenericRepository<User> userRepo, IGenericRepository<Role> roleRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }
        public async Task<bool> RegisterUser(User user)
        {
            bool userDtls = _userRepo.SearchFor(x => x.LastName == user.LastName).Any();
            if(userDtls)
            {
                return false;
            }
            else
            {
                var name = user.RoleName;
                var role = _roleRepo.SearchFor(x => x.Name == name).FirstOrDefault();
                user.RoleId = role?.Id ?? 1;
                try
                {
                    await _userRepo.AddAsync(user);
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }
        public async Task<User?> ValidateUser(LoginDTO loginDTO)
        {
            var user = _userRepo.SearchFor(u => u.Email == loginDTO.Email).FirstOrDefault();
            if (user == null) return null;

            bool ok = Verify(loginDTO.Password, user.Password);
            return ok ? user : null;
        }
    }
}
