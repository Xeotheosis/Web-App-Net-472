using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IBuildingRepository
    {
        Task AddBuildingAsync(Building building);
        Task<IEnumerable<Building>> GetBuildingsByAssociationIdAsync(int associationId); // Noua funcție
        IEnumerable<Building> GetBuildings();
        void DeleteBuilding(int buildingId);
        Task UpdateBuildingAsync(Building building);
    }
}
