using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public class BuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task AddBuildingAsync(int associationId, string name)
        {
            var building = new Building
            {
                AssociationId = associationId,
                Name = name
            };
            await _buildingRepository.AddBuildingAsync(building);
        }

        public IEnumerable<Building> GetBuildings()
        {
            return _buildingRepository.GetBuildings();
        }

        public void DeleteBuilding(int buildingId)
        {
            _buildingRepository.DeleteBuilding(buildingId);
        }

        public async Task<IEnumerable<Building>> GetBuildingsByAssociationIdAsync(int associationId)
        {
            return await _buildingRepository.GetBuildingsByAssociationIdAsync(associationId);
        }

        public async Task UpdateBuildingAsync(Building building)
        {
            await _buildingRepository.UpdateBuildingAsync(building);
        }
    }
}
