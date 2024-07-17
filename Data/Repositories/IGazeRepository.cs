using ClassLibraryEntityFrameworkClaseAsProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IGazeRepository
    {
        Task<IEnumerable<tblGaze>> GetAllAsync(int id);
        Task<tblGaze> GetByIdAsync(int id);
        Task AddAsync(tblGaze factura);
        Task UpdateAsync(tblGaze factura);
        Task DeleteAsync(int id);
    }
}
