using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IAccessLogRepository
    {
        Task LogAccessAsync(AccessLog accessLog);
        Task<IEnumerable<AccessLog>> GetAccessLogsAsync(DateTime from, DateTime to, int pageIndex, int pageSize);
    }
}
