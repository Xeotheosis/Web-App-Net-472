using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public class ApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;

        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public async Task AddApartmentAsync(int staircaseId, bool hasGasCentralHeating, float surfaceArea, int peopleCount, float? coldWaterMeterReading, float? hotWaterMeterReading)
        {
            var nextNumber = await _apartmentRepository.GetNextApartmentNumberAsync(staircaseId);

            var apartment = new Apartment
            {
                StaircaseId = staircaseId,
                Number = nextNumber.ToString(),
                HasGasCentralHeating = hasGasCentralHeating,
                SurfaceArea = surfaceArea,
                PeopleCount = peopleCount,
                ColdWaterMeterReading = coldWaterMeterReading,
                HotWaterMeterReading = hotWaterMeterReading
            };
            await _apartmentRepository.AddApartmentAsync(apartment);
        }

        public IEnumerable<Apartment> GetApartments()
        {
            return _apartmentRepository.GetApartments();
        }
        public async Task<IEnumerable<Apartment>> GetApartmentsByStaircaseIdAsync(int staircaseId)
        {
            return await _apartmentRepository.GetApartmentsByStaircaseIdAsync(staircaseId);
        }
        public void DeleteApartment(int apartmentId)
        {
            _apartmentRepository.DeleteApartment(apartmentId);
        }

        public async Task UpdateApartmentAsync(int apartmentId, int staircaseId, string number, bool hasGasCentralHeating, float surfaceArea, int peopleCount, float? coldWaterMeterReading, float? hotWaterMeterReading)
        {
            var apartment = new Apartment
            {
                ApartmentId = apartmentId,
                StaircaseId = staircaseId,
                Number = number,
                HasGasCentralHeating = hasGasCentralHeating,
                SurfaceArea = surfaceArea,
                PeopleCount = peopleCount,
                ColdWaterMeterReading = coldWaterMeterReading,
                HotWaterMeterReading = hotWaterMeterReading
            };
            await _apartmentRepository.UpdateApartmentAsync(apartment);
        }

        public async Task<Apartment> GetApartmentByIdAsync(int apartmentId)
        {
            return await _apartmentRepository.GetApartmentByIdAsync(apartmentId);
        }


    }
}
