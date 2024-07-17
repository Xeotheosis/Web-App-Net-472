using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public class AssociationService
    {
        private readonly IAssociationRepository _associationRepository;

        public AssociationService(IAssociationRepository associationRepository)
        {
            _associationRepository = associationRepository;
        }

        public async Task AddAssociationAsync(string name)
        {
            var association = new Association
            {
                Name = name
            };
            await _associationRepository.AddAssociationAsync(association);
        }
        public async Task<Association> GetAssociationByIdAsync(int associationId)
        {
            return await _associationRepository.GetAssociationByIdAsync(associationId);
        }
        public async Task UpdateAssociationAsync(Association association)
        {
            await _associationRepository.UpdateAssociationAsync(association);
        }

        public IEnumerable<Association> GetAssociations()
        {
            return _associationRepository.GetAssociations();
        }

        //public void DeleteAssociation(int associationId)
        //{
        //    _associationRepository.DeleteAssociation(associationId);
        //}
        public async Task DeleteAssociationAsync(int associationId)
        {
            await _associationRepository.DeleteAssociationAsync(associationId);
        }
        public IEnumerable<User> GetAdministratorsByAssociation(int associationId)
        {
            return _associationRepository.GetAdministratorsByAssociation(associationId);
        }

        public async Task AssignAdminToAssociationAsync(int associationId, string username)
        {
            var association = _associationRepository.GetAssociations().FirstOrDefault(a => a.AssociationId == associationId);
            if (association != null)
            {
                association.AddAdmin(username);
                await _associationRepository.UpdateAssociationAsync(association);
            }
        }

        public async Task RemoveAdminFromAssociationAsync(int associationId, string username)
        {
            var association = _associationRepository.GetAssociations().FirstOrDefault(a => a.AssociationId == associationId);
            if (association != null)
            {
                association.RemoveAdmin(username);
                await _associationRepository.UpdateAssociationAsync(association);
            }
        }
    }
}
