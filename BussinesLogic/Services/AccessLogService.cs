using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
     
    public class AccessLogService
    {
        private readonly IAccessLogRepository _accessLogRepository;

        public AccessLogService(IAccessLogRepository accessLogRepository)
        {
            _accessLogRepository = accessLogRepository;
        }

        public async Task LogAccessAsync(int userId, string username, string action, string details)
        {
            var accessLog = new AccessLog
            {
                UserId = userId,
                Username = username,
                Action = action,
                Timestamp = DateTime.UtcNow,
                Details = details
            };
            await _accessLogRepository.LogAccessAsync(accessLog);
        }

        public async Task<IEnumerable<AccessLog>> GetAccessLogsAsync(DateTime from, DateTime to, int pageIndex, int pageSize)
        {
            return await _accessLogRepository.GetAccessLogsAsync(from, to, pageIndex, pageSize);
        }
    }

}
