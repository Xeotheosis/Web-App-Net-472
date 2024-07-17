using ClassLibraryEntityFrameworkClaseAsProp;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public class CurentCasaScariiService
    {
        private readonly ICurentCasaScariiRepository _curentCasaScariiRepository;
        public CurentCasaScariiService(ICurentCasaScariiRepository  curentCasaScariiRepository)
        {
            _curentCasaScariiRepository = curentCasaScariiRepository;
        }

        public async Task<IEnumerable<tblEE>> GetAllAsync(int id)
        {
            return await _curentCasaScariiRepository.GetAllAsync(id);
        }

        public async Task UpdateAsync(tblEE factura)
        {
            await _curentCasaScariiRepository.UpdateAsync(factura);
        }
    }
}
