using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IStaircaseRepository
    {
        Task AddStaircaseAsync(Staircase staircase);
        Task<IEnumerable<Staircase>> GetStaircasesByBuildingIdAsync(int buildingId); // Noua funcție
        IEnumerable<Staircase> GetStaircases();
        void DeleteStaircase(int staircaseId);
        Task UpdateStaircaseAsync(Staircase staircase);
    }
}
