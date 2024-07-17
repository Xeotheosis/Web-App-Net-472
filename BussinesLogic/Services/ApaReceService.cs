using ClassLibraryEntityFrameworkClaseAsProp;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public class ApaReceService
    {
        private readonly IApaReceRepository  _apaReceRepository;
        public ApaReceService(IApaReceRepository apaReceRepository)
        {
                _apaReceRepository = apaReceRepository;
        }

        public async Task<IEnumerable<tblAR>> GetAllAsync(int id)
        {
            return await _apaReceRepository.GetAllAsync(id);
        }

        public async Task UpdateAsync(tblAR factura)
        {
            await _apaReceRepository.UpdateAsync(factura);
        }
    }
}
