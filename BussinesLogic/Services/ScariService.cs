using ClassLibraryEntityFrameworkClaseAsProp;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public class ScariService
    {
        private readonly IScariRepository  _scariRepository;
        public ScariService(IScariRepository  scariRepository)
        {
            _scariRepository  = scariRepository;
        }

        public async Task<IEnumerable<tblScari >> GetAllAsync(int id)
        {
            return await _scariRepository.GetAllAsync(id);
        }

        public async Task UpdateAsync(tblScari factura)
        {
            await _scariRepository.UpdateAsync(factura);
        }
    }
}
