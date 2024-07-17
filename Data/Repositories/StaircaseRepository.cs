using Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Data.Repositories
{
    public class StaircaseRepository : IStaircaseRepository
    {
        private readonly string _connectionString;

        public StaircaseRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString; 
        }

        public async Task AddStaircaseAsync(Staircase staircase)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Staircases (BuildingId, Name) VALUES (@BuildingId, @Name)";
                await connection.ExecuteAsync(sql, staircase);
            }
        }
        public async Task<IEnumerable<Staircase>> GetStaircasesByBuildingIdAsync(int buildingId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Staircases WHERE BuildingId = @BuildingId";
                return await connection.QueryAsync<Staircase>(sql, new { BuildingId = buildingId });
            }
        }
        public IEnumerable<Staircase> GetStaircases()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Staircases";
                var staircases = connection.Query<Staircase>(sql).ToList();

                foreach (var staircase in staircases)
                {
                    var apartments = connection.Query<Apartment>("SELECT * FROM Apartments WHERE StaircaseId = @StaircaseId", new { StaircaseId = staircase.StaircaseId }).ToList();
                    staircase.Apartments = apartments;
                }

                return staircases;
            }
        }

        public void DeleteStaircase(int staircaseId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Staircases WHERE StaircaseId = @StaircaseId";
                connection.Execute(sql, new { StaircaseId = staircaseId });
            }
        }
        public async Task UpdateStaircaseAsync(Staircase staircase)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE Staircases SET Name = @Name, BuildingId = @BuildingId WHERE StaircaseId = @StaircaseId";
                await connection.ExecuteAsync(sql, staircase);
            }
        }
    }
}
