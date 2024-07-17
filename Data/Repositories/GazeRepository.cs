using ClassLibraryEntityFrameworkClaseAsProp;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GazeRepository : IGazeRepository
    {
        private readonly string _connectionString;
        public GazeRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString;
        }
        public Task AddAsync(tblGaze factura)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<tblGaze>> GetAllAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM tblGaze where idAsoc=@id";
                return await connection.QueryAsync<tblGaze>(sql, new { id });
            }
        }

        public Task<tblGaze> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(tblGaze factura)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "Update tblGaze " +
                    "set Valoare=@Valoare " +
                    "where idFactGaze=@idFactGaze";
                await connection.ExecuteAsync(sql, factura);
            }
        }
    }
}
