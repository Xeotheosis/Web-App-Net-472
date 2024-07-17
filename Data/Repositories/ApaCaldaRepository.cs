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
    public class ApaCaldaRepository:IApaCaldaRepository 
    {
        readonly string _connectionString;
        public ApaCaldaRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString;
        }

        public Task AddAsync(tblACM factura)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<tblACM>> GetAllAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM tblACM where idAsoc=@id";
                return await connection.QueryAsync<tblACM>(sql, new { id });
            }
        }

        public Task<tblACM> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task UpdateAsync(tblACM factura)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "Update tblACM " +
                    "set NrGcal=@NrGcal ," +
                    "ValGcal=@ValGcal," +
                    "m3AR=@m3AR, " +
                    "ValAR=@ValAR, " +
                    "ValTotACM=@ValTotACM " +
                    "where idFacturaACM=@idFacturaACM";
                await connection.ExecuteAsync(sql, factura);
            };
        }
    }
}
