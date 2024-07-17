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
    public class CurentCasaScariiRepository : ICurentCasaScariiRepository
    {
        private readonly string _connectionString;
        public CurentCasaScariiRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString;
        }
        public  async Task AddAsync(tblEE factura)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<tblEE>> GetAllAsync(int idAsoc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM tblEE where idAsoc=@idAsoc";
                return await connection.QueryAsync<tblEE>(sql, new { idAsoc });
            }
        }

        public async Task<tblEE> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(tblEE factura)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "Update tblEE " +
                    "set Valoare=@Valoare " +
                    "where idFactEE=@idFactEE";
                await connection.ExecuteAsync(sql, factura);
            }
        }
    }
}
