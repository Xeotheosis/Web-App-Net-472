using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUserAsync(string utilizator, string parola, string role)
        {
            var passwordHash = HashPassword(parola);
            var user = new User
            {
                UserName  = utilizator,
                PasswordHash = passwordHash,
                Role = role,
                AdministeredAssociations = string.Empty // Inițializare AdministeredAssociations cu un șir gol
            };
            await _userRepository.AddUserAsync(user);
        }

        public async Task<User> ValidateUserAsync(string utilizator, string parola)
        {
            var user = await _userRepository.GetUserByUsernameAsync(utilizator);
            if (user == null || !VerifyPassword(parola, user.PasswordHash))
            {
                return null;
            }
            return user;
        }

        public IEnumerable<User> GetUsersByRole(string role)
        {
            return _userRepository.GetUsersByRole(role);
        }

        public async Task<User>  GetUserByUsernameAsync(string username)
        {
            return  await _userRepository.GetUserByUsernameAsync(username);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }
        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }
        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task AssignAssociationToUserAsync(int userId, int associationId)
        {
            await _userRepository.AssignAssociationToUserAsync(userId, associationId);
        }

        public IEnumerable<Association> GetUserAssociations(int userId)
        {
            return _userRepository.GetUserAssociations(userId);
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }
        public async Task<int> GetUserIdByUsernameAsync(string username)
        {
            return await _userRepository.GetUserIdByUsernameAsync(username);
        }
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private bool VerifyPassword(string password, string hash)
        {
            var passwordHash = HashPassword(password);
            return passwordHash == hash;
        }

        public async Task AddAdministeredAssociationToUserAsync(int userId, string associationName)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            user.AddAdministeredAssociation(associationName);
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task RemoveAdministeredAssociationFromUserAsync(int userId, string associationName)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            user.RemoveAdministeredAssociation(associationName);
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
