using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Association
    {
        public int AssociationId { get; set; }
        public string Name { get; set; }
        public ICollection<Building> Buildings { get; set; }
        public ICollection<User> Administrators { get; set; }
        public string AdminUsernames { get; set; }
        public Association()
        {
            Buildings = new List<Building>();
            Administrators = new List<User>();
        }
        // Metodă pentru a adăuga un administrator
        public void AddAdmin(string username)
        {
            var admins = AdminUsernames?.Split(',').ToList() ?? new List<string>();
            if (!admins.Contains(username))
            {
                admins.Add(username);
                AdminUsernames = string.Join(",", admins);
            }
        }

        // Metodă pentru a elimina un administrator
        public void RemoveAdmin(string username)
        {
            var admins = AdminUsernames?.Split(',').ToList() ?? new List<string>();
            if (admins.Contains(username))
            {
                admins.Remove(username);
                AdminUsernames = string.Join(",", admins);
            }
        }
    }

}
