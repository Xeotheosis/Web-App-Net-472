using ClassLibraryEntityFrameworkClaseAsProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IApartamentRepository
    {
        Task<IEnumerable<tblApart>> GetAllByIdScaraAsync(int idScara);
        Task<tblApart> GetByIdAsync(int id);
        Task AddAsync(tblApart apartament);
        Task UpdateAsync(tblApart apartament);
        Task DeleteAsync(int id);
    }
}
