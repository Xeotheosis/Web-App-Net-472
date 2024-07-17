using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
namespace Data.Repositories
{

    public class AccessLogRepository : IAccessLogRepository
    {
        private readonly string _connectionString;

        public AccessLogRepository( )
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString;
        }

        public async Task LogAccessAsync(AccessLog accessLog)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO AccessLogs (UserId, Username, Action, Timestamp, Details) VALUES (@UserId, @Username, @Action, @Timestamp, @Details)";
                await connection.ExecuteAsync(sql, accessLog);
            }
        }

        public async Task<IEnumerable<AccessLog>> GetAccessLogsAsync(DateTime from, DateTime to, int pageIndex, int pageSize)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT * FROM AccessLogs 
                            WHERE Timestamp BETWEEN @From AND @To 
                            ORDER BY Timestamp DESC 
                            OFFSET @Offset ROWS 
                            FETCH NEXT @PageSize ROWS ONLY";
                return await connection.QueryAsync<AccessLog>(sql, new { From = from, To = to, Offset = pageIndex * pageSize, PageSize = pageSize });
            }
        }
    }
}
