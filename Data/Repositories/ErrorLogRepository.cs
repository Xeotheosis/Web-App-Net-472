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
    public class ErrorLogRepository : IErrorLogRepository
    {
        private readonly string _connectionString;

        public ErrorLogRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString;
        }

        public async Task LogErrorAsync(ErrorLog errorLog)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO ErrorLogs (UserId, Username, ErrorMessage, StackTrace, Timestamp) VALUES (@UserId, @Username, @ErrorMessage, @StackTrace, @Timestamp)";
                await connection.ExecuteAsync(sql, errorLog);
            }
        }
        public async Task<IEnumerable<ErrorLog>> GetErrorLogsAsync(int pageIndex, int pageSize)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT * FROM ErrorLogs 
                            ORDER BY Timestamp ASC 
                            OFFSET @Offset ROWS 
                            FETCH NEXT @PageSize ROWS ONLY";
                return await connection.QueryAsync<ErrorLog>(sql, new { Offset = pageIndex * pageSize, PageSize = pageSize });
            }
        }

        public async Task DeleteErrorLogAsync(int logId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM ErrorLogs WHERE LogId = @LogId";
                await connection.ExecuteAsync(sql, new { LogId = logId });
            }
        }
    }
}
