using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IApartmentRepository
    {
        Task AddApartmentAsync(Apartment apartment);
        Task<IEnumerable<Apartment>> GetApartmentsByStaircaseIdAsync(int staircaseId); // Noua funcție
        IEnumerable<Apartment> GetApartments();
        void DeleteApartment(int apartmentId);
        Task UpdateApartmentAsync(Apartment apartment);
        Task<Apartment> GetApartmentByIdAsync(int apartmentId); // Noua funcție
        Task<int> GetNextApartmentNumberAsync(int staircaseId); // Noua funcție
    }
}
