using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByIdAsync(int userId);
        Task UpdateUserAsync(User user);
        IEnumerable<User> GetUsersByRole(string role);
        void DeleteUser(int userId);
        Task DeleteUserAsync(int userId);
        User GetUserByUsername(string username);
        Task AssignAssociationToUserAsync(int userId, int associationId);
        IEnumerable<Association> GetUserAssociations(int userId);
        Task<int> GetUserIdByUsernameAsync(string username); // Noua funcție

    }
}