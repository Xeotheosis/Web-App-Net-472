using ClassLibraryEntityFrameworkClaseAsProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IApaReceRepository
    {
        Task<IEnumerable<tblAR>> GetAllAsync(int id);
        Task<tblAR> GetByIdAsync(int id);
        Task AddAsync(tblAR factura);
        Task UpdateAsync(tblAR factura);
        Task DeleteAsync(int id);
        
    }
}
