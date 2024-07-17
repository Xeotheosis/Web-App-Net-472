using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public class StaircaseService
    {
        private readonly IStaircaseRepository _staircaseRepository;

        public StaircaseService(IStaircaseRepository staircaseRepository)
        {
            _staircaseRepository = staircaseRepository;
        }

        public async Task AddStaircaseAsync(int buildingId, string name)
        {
            var staircase = new Staircase
            {
                BuildingId = buildingId,
                Name = name
            };
            await _staircaseRepository.AddStaircaseAsync(staircase);
        }

        public async Task<IEnumerable<Staircase>> GetStaircasesByBuildingIdAsync(int buildingId)
        {
            return await _staircaseRepository.GetStaircasesByBuildingIdAsync(buildingId);
        }

        public IEnumerable<Staircase> GetStaircases()
        {
            return _staircaseRepository.GetStaircases();
        }

        public void DeleteStaircase(int staircaseId)
        {
            _staircaseRepository.DeleteStaircase(staircaseId);
        }

        public async Task UpdateStaircaseAsync(Staircase staircase)
        {
            await _staircaseRepository.UpdateStaircaseAsync(staircase);
        }
    }
}
