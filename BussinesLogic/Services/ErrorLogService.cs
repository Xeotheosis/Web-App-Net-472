using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public class ErrorLogService
    {
        private readonly IErrorLogRepository _errorLogRepository;

        public ErrorLogService(IErrorLogRepository errorLogRepository)
        {
            _errorLogRepository = errorLogRepository;
        }

        public async Task LogErrorAsync(int? userId, string username, string errorMessage, string stackTrace)
        {
            var errorLog = new ErrorLog
            {
                UserId = userId,
                Username = username,
                ErrorMessage = errorMessage,
                StackTrace = stackTrace,
                Timestamp = DateTime.UtcNow
            };
            await _errorLogRepository.LogErrorAsync(errorLog);
        }

        public async Task<IEnumerable<ErrorLog>> GetErrorLogsAsync(int pageIndex, int pageSize)
        {
            return await _errorLogRepository.GetErrorLogsAsync(pageIndex, pageSize);
        }

        public async Task DeleteErrorLogAsync(int logId)
        {
            await _errorLogRepository.DeleteErrorLogAsync(logId);
        }
    }
}
