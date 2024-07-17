using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IErrorLogRepository
    {
        Task LogErrorAsync(ErrorLog errorLog);
        Task<IEnumerable<ErrorLog>> GetErrorLogsAsync(int pageIndex, int pageSize);
        Task DeleteErrorLogAsync(int logId);

    }
}
