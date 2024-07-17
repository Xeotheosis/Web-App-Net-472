using ClassLibraryEntityFrameworkClaseAsProp;
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
    public class ApartamentRepository : IApartamentRepository
    {
        private readonly string _connectionString;

        public ApartamentRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString;

        }
        public async Task AddAsync(tblApart apartament)
        {
            throw new NotImplementedException();
        }

        public async  Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<tblApart>> GetAllByIdScaraAsync(int idScara)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM tblApart WHERE idScara = @idScara order by nr";
                return await connection.QueryAsync<tblApart>(sql, new { idScara = idScara });
            }
        }

        public async  Task<tblApart> GetByIdAsync(int idApart)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM tblApart WHERE idApart = @idApart";
                return await connection.QuerySingleOrDefaultAsync<tblApart>(sql, new { idApart });
            }
        }

        public async Task UpdateAsync(tblApart apartament)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE tblApart SET " +
                    "nrPers = @nrPers, " +
                    "cpi = @cpi, " +
                    "proprietar = @proprietar, " +
                    "suprafata = @suprafata, " +
                    "contorizare = @contorizare, " +
                    "caldura = @caldura, " +
                    "Restante = @Restante, " +
                    "Penalitati = @Penalitati, " +
                    "consumAr = @consumAr, " +
                    "consumACM = @consumACM " +
                    "WHERE idApart = @idApart";
                await connection.ExecuteAsync(sql, apartament);
            }
        }
    }
}
