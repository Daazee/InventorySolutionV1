using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;

namespace Inventory.DAL
{
 public  class RoleDA
    {
        public InventoryContext context = new InventoryContext();
        public IEnumerable<Role> GetAllRoles()
        {
            return context.Roles.ToList();
        }
    }
}
