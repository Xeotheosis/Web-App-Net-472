using ClassLibraryEntityFrameworkClaseAsProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IApaCaldaRepository
    {
        Task<IEnumerable<tblACM>> GetAllAsync(int id);
        Task<tblACM> GetByIdAsync(int id);
        Task AddAsync(tblACM factura);
        Task UpdateAsync(tblACM factura);
        Task DeleteAsync(int id);
    }
}
