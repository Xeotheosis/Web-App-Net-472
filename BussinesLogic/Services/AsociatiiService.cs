using ClassLibraryEntityFrameworkClaseAsProp;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public class AsociatiiService 
    {
        private readonly IAsociatiiRepository _asociatiiRepository;

        public AsociatiiService(IAsociatiiRepository asociatiiRepository)
        {
            _asociatiiRepository = asociatiiRepository;
        }

        public async Task<IEnumerable<tblAsociatii>> GetAllAsync()
        {
            return await _asociatiiRepository.GetAllAsync();
        }

        public async Task<tblAsociatii> GetByIdAsync(int id)
        {
            return await _asociatiiRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(tblAsociatii asociatie)
        {
            await _asociatiiRepository.AddAsync(asociatie);
        }

        public async Task UpdateAsync(tblAsociatii asociatie)
        {
            await _asociatiiRepository.UpdateAsync(asociatie);
        }

        public async Task DeleteAsync(int id)
        {
            await _asociatiiRepository.DeleteAsync(id);
        }
    }
}
