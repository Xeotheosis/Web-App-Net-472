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
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly string _connectionString;

        public ApartmentRepository( )
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString; 
        }
        public async Task<IEnumerable<Apartment>> GetApartmentsByStaircaseIdAsync(int staircaseId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Apartments WHERE StaircaseId = @StaircaseId";
                return await connection.QueryAsync<Apartment>(sql, new { StaircaseId = staircaseId });
            }
        }

        public async Task AddApartmentAsync(Apartment apartment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Apartments (StaircaseId, Number, HasGasCentralHeating, SurfaceArea, PeopleCount, ColdWaterMeterReading, HotWaterMeterReading) VALUES (@StaircaseId, @Number, @HasGasCentralHeating, @SurfaceArea, @PeopleCount, @ColdWaterMeterReading, @HotWaterMeterReading)";
                await connection.ExecuteAsync(sql, apartment);
            }
        }

        public IEnumerable<Apartment> GetApartments()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Apartments";
                return connection.Query<Apartment>(sql).ToList();
            }
        }

        public void DeleteApartment(int apartmentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Apartments WHERE ApartmentId = @ApartmentId";
                connection.Execute(sql, new { ApartmentId = apartmentId });
            }
        }

        public async Task UpdateApartmentAsync(Apartment apartment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE Apartments SET Number = @Number, StaircaseId = @StaircaseId, HasGasCentralHeating = @HasGasCentralHeating, SurfaceArea = @SurfaceArea, PeopleCount = @PeopleCount, ColdWaterMeterReading = @ColdWaterMeterReading, HotWaterMeterReading = @HotWaterMeterReading WHERE ApartmentId = @ApartmentId";
                await connection.ExecuteAsync(sql, apartment);
            }
        }
        public async Task<Apartment> GetApartmentByIdAsync(int apartmentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Apartments WHERE ApartmentId = @ApartmentId";
                return await connection.QuerySingleOrDefaultAsync<Apartment>(sql, new { ApartmentId = apartmentId });
            }
        }

        public async Task<int> GetNextApartmentNumberAsync(int staircaseId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT ISNULL(MAX(Number), 0) + 1 FROM Apartments WHERE StaircaseId = @StaircaseId";
                return await connection.ExecuteScalarAsync<int>(sql, new { StaircaseId = staircaseId });
            }
        }
    }
}
