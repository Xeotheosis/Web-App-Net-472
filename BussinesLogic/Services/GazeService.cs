using ClassLibraryEntityFrameworkClaseAsProp;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public class GazeService
    {
        private readonly IGazeRepository  _gazeRepository;     
        public GazeService(IGazeRepository gazeRepository)
        {
            _gazeRepository = gazeRepository;  
        }

        public async Task<IEnumerable<tblGaze>> GetAllAsync(int id)
        {
            return await _gazeRepository.GetAllAsync(id);
        }

        public async Task UpdateAsync(tblGaze factura)
        {
            await _gazeRepository.UpdateAsync(factura);
        }
    }
}
