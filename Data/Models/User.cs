using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public ICollection<Association> Associations { get; set; }
        public string AdministeredAssociations { get; set; } // Noua proprietate
        public User()
        {
            Associations = new List<Association>();
        }

        // Metodă pentru a adăuga o asociație administrată
        public void AddAdministeredAssociation(string associationName)
        {
            var associations = AdministeredAssociations?.Split(',').ToList() ?? new List<string>();
            if (!associations.Contains(associationName))
            {
                associations.Add(associationName);
                AdministeredAssociations = string.Join(",", associations);
            }
        }

        // Metodă pentru a elimina o asociație administrată
        public void RemoveAdministeredAssociation(string associationName)
        {
            var associations = AdministeredAssociations?.Split(',').ToList() ?? new List<string>();
            if (associations.Contains(associationName))
            {
                associations.Remove(associationName);
                AdministeredAssociations = string.Join(",", associations);
            }
        }
    }
}
