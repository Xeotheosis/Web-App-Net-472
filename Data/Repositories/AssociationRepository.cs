using Dapper;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AssociationRepository : IAssociationRepository
    {
        private readonly string _connectionString;

        public AssociationRepository( )
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString; 
        }

        public async Task AddAssociationAsync(Association association)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Associations (Name) VALUES (@Name)";
                await connection.ExecuteAsync(sql, association);
            }
        }

        public IEnumerable<Association> GetAssociations()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Associations";
                var associations = connection.Query<Association>(sql).ToList();

                foreach (var association in associations)
                {
                    var buildings = connection.Query<Building>("SELECT * FROM Buildings WHERE AssociationId = @AssociationId", new { AssociationId = association.AssociationId }).ToList();
                    association.Buildings = buildings;

                    foreach (var building in buildings)
                    {
                        var staircases = connection.Query<Staircase>("SELECT * FROM Staircases WHERE BuildingId = @BuildingId", new { BuildingId = building.BuildingId }).ToList();
                        building.Staircases = staircases;

                        foreach (var staircase in staircases)
                        {
                            var apartments = connection.Query<Apartment>("SELECT * FROM Apartments WHERE StaircaseId = @StaircaseId", new { StaircaseId = staircase.StaircaseId }).ToList();
                            staircase.Apartments = apartments;
                        }
                    }
                }

                return associations;
            }
        }
        public async Task<Association> GetAssociationByIdAsync(int associationId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Associations WHERE AssociationId = @AssociationId";
                return await connection.QuerySingleOrDefaultAsync<Association>(sql, new { AssociationId = associationId });
            }
        }
        public async Task DeleteAssociationAsync(int associationId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM UserAssociations WHERE AssociationId = @AssociationId";
                await connection.ExecuteAsync(sql, new { AssociationId = associationId });

                sql = "DELETE FROM Associations WHERE AssociationId = @AssociationId";
                await connection.ExecuteAsync(sql, new { AssociationId = associationId });
            }
        }

        public IEnumerable<User> GetAdministratorsByAssociation(int associationId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT u.* FROM Users u
                            INNER JOIN UserAssociations ua ON u.UserId = ua.UserId
                            WHERE ua.AssociationId = @AssociationId";
                return connection.Query<User>(sql, new { AssociationId = associationId }).ToList();
            }
        }
        public async Task UpdateAssociationAsync(Association association)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE Associations SET Name = @Name, AdminUsernames = @AdminUsernames WHERE AssociationId = @AssociationId";
                await connection.ExecuteAsync(sql, association);
            }
        }
    }
}
