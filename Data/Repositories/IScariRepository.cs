using ClassLibraryEntityFrameworkClaseAsProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IScariRepository
    {
        Task<IEnumerable<tblScari>> GetAllAsync(int id);
        Task<tblScari> GetByIdAsync(int id);
        Task AddAsync(tblScari scara);
        Task UpdateAsync(tblScari scara);
        Task DeleteAsync(int id);
    }
}
