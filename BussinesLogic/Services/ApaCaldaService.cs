using ClassLibraryEntityFrameworkClaseAsProp;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public class ApaCaldaService
    {
        private readonly IApaCaldaRepository _apaCaldaRepository;
        public ApaCaldaService(IApaCaldaRepository apaCaldaRepository) 
        {
            _apaCaldaRepository = apaCaldaRepository;
        }

        public async Task<IEnumerable<tblACM>> GetAllAsync(int id)
        {
            return await _apaCaldaRepository.GetAllAsync(id);
        }

        public async Task UpdateAsync(tblACM factura)
        {
            await _apaCaldaRepository.UpdateAsync(factura);
        }
    }
}
