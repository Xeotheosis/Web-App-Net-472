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
    public class ScariRepository:IScariRepository
    {
        private readonly string _connectionString;
        public ScariRepository() 
        { 
            _connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString; 
        }

        public Task AddAsync(tblScari scara)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<tblScari>> GetAllAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "select tblscari.*, tblblocuri.bloc +  ' - ' + tblscari.nume as NumeScara from tblScari " +
                    " join tblblocuri on tblscari.idBloc=tblBlocuri.idBloc where tblscari.idAsoc=@id order by tblscari.idasoc, ordine ";
                return await connection.QueryAsync<tblScari>(sql, new { id });
            }
        }

        public async Task<tblScari> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(tblScari scara)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "Update tblScari " +
                    "set cpp2asoc=@cpp2asoc  " +
                    "where idScara=@idScara" ;
                await connection.ExecuteAsync(sql, scara);
            }
        }
    }
}
