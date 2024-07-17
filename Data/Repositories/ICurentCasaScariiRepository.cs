using ClassLibraryEntityFrameworkClaseAsProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ICurentCasaScariiRepository
    {
        Task<IEnumerable<tblEE>> GetAllAsync(int id);
        Task<tblEE> GetByIdAsync(int id);
        Task AddAsync(tblEE factura);
        Task UpdateAsync(tblEE factura);
        Task DeleteAsync(int id);
    }
}
