using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface  IAssociationRepository
    {
        Task AddAssociationAsync(Association association);
        Task<Association> GetAssociationByIdAsync(int associationId);
        IEnumerable<Association> GetAssociations();
        //void DeleteAssociation(int associationId);
        IEnumerable<User> GetAdministratorsByAssociation(int associationId);
        Task UpdateAssociationAsync(Association association); // Adăugăm o metodă pentru actualizarea asociației
        Task DeleteAssociationAsync(int associationId);
    }
}
