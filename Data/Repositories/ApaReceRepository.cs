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
    public class ApaReceRepository : IApaReceRepository
    {
        private readonly string _connectionString;
        public ApaReceRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString;
        }

        public Task AddAsync(tblAR factura)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<tblAR>> GetAllAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM tblAr where idAsoc=@id";
                return await connection.QueryAsync<tblAR>(sql,new {id});
            }
        }

        public async Task<tblAR> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(tblAR factura)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "Update tblAr " +
                    "set ValoareFaraApaMeteo=@ValoareFaraApaMeteo ," +
                    "Valoare=@ValoareFaraApaMeteo," +
                    "m3=@m3 " +
                    "where idFactAr=@idFactAr";
                await connection.ExecuteAsync(sql, factura );
            }
        }
 
    }
}
