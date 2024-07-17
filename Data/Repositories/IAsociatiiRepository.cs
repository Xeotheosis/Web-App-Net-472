using ClassLibraryEntityFrameworkClaseAsProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IAsociatiiRepository
    {
        Task<IEnumerable<tblAsociatii>> GetAllAsync();
        Task<tblAsociatii> GetByIdAsync(int id);
        Task AddAsync(tblAsociatii asociatie);
        Task UpdateAsync(tblAsociatii asociatie);
        Task DeleteAsync(int id);
    }
}
