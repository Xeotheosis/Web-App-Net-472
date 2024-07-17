using Dapper;
using Data.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Users WHERE Username = @Username";
                return await connection.QuerySingleOrDefaultAsync<User>(sql, new { Username = username });
            }
        }
        public async Task UpdateUserAsync(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE Users SET Username = @Username, PasswordHash = @PasswordHash, Role = @Role, AdministeredAssociations = @AdministeredAssociations WHERE UserId = @UserId";
                await connection.ExecuteAsync(sql, user);
            }
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Users WHERE UserId = @UserId";
                return await connection.QuerySingleOrDefaultAsync<User>(sql, new { UserId = userId });
            }
        }

        public User GetUserByUsername(string username) 
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Users WHERE Username = @Username";
                return connection.QuerySingleOrDefault<User>(sql, new { Username = username });
            }
        }


        public async Task AddUserAsync(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Users (Username, PasswordHash, Role, AdministeredAssociations) VALUES (@Username, @PasswordHash, @Role, @AdministeredAssociations)";
                await connection.ExecuteAsync(sql, user);
            }
        }
        public IEnumerable<User> GetUsersByRole(string role)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Users WHERE Role = @Role";
                return connection.Query<User>(sql, new { Role = role }).ToList();
            }
        }

        public void DeleteUser(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Users WHERE UserId = @UserId";
                connection.Execute(sql, new { UserId = userId });
            }
        }
        public async Task DeleteUserAsync(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM UserAssociations WHERE UserId = @UserId";
                await connection.ExecuteAsync(sql, new { UserId = userId });

                sql = "DELETE FROM Users WHERE UserId = @UserId";
                await connection.ExecuteAsync(sql, new { UserId = userId });
            }
        }

        public async Task AssignAssociationToUserAsync(int userId, int associationId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO UserAssociations (UserId, AssociationId) VALUES (@UserId, @AssociationId)";
                await connection.ExecuteAsync(sql, new { UserId = userId, AssociationId = associationId });
            }
        }

        public IEnumerable<Association> GetUserAssociations(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT a.* FROM Associations a INNER JOIN UserAssociations ua ON a.AssociationId = ua.AssociationId WHERE ua.UserId = @UserId";
                return connection.Query<Association>(sql, new { UserId = userId }).ToList();
            }
        }
        public async Task<int> GetUserIdByUsernameAsync(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT UserId FROM Users WHERE Username = @Username";
                return await connection.QuerySingleOrDefaultAsync<int>(sql, new { Username = username });
            }
        }
    }
}
