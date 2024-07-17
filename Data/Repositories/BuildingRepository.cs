using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Data.Models;
using System.Data.SqlClient;
using Dapper;


namespace Data.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly string _connectionString;

        public BuildingRepository( )
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString; 
        }

        public async Task AddBuildingAsync(Building building)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Buildings (AssociationId, Name) VALUES (@AssociationId, @Name)";
                await connection.ExecuteAsync(sql, building);
            }
        }
        public async Task<IEnumerable<Building>> GetBuildingsByAssociationIdAsync(int associationId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Buildings WHERE AssociationId = @AssociationId";
                return await connection.QueryAsync<Building>(sql, new { AssociationId = associationId });
            }
        }
        public IEnumerable<Building> GetBuildings()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Buildings";
                var buildings = connection.Query<Building>(sql).ToList();

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

                return buildings;
            }
        }

        public void DeleteBuilding(int buildingId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Buildings WHERE BuildingId = @BuildingId";
                connection.Execute(sql, new { BuildingId = buildingId });
            }
        }
        public async Task UpdateBuildingAsync(Building building)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE Buildings SET Name = @Name, AssociationId = @AssociationId WHERE BuildingId = @BuildingId";
                await connection.ExecuteAsync(sql, building);
            }
        }

    }
}
