using ClassLibraryEntityFrameworkClaseAsProp;
using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public class ApartamentService
    {
        private readonly IApartamentRepository _apartamentRepository;
        public ApartamentService(IApartamentRepository apartamentRepository) 
        {
            _apartamentRepository = apartamentRepository;
        }
        public async Task<IEnumerable<tblApart>> GetAllByIdScaraAsync(int idScara)
        {
            return await _apartamentRepository.GetAllByIdScaraAsync(idScara);
        }
        public void DeleteApartment(int apartmentId)
        {
            _apartamentRepository.DeleteAsync(apartmentId);
        }

        public async Task UpdateAsync(tblApart apartament)
        {
            
            await _apartamentRepository.UpdateAsync(apartament);
        }

        public async Task<tblApart> GetByIdAsync(int apartmentId)
        {
            return await _apartamentRepository.GetByIdAsync(apartmentId);
        }
    }
}
