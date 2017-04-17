using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using Inventory.Model;

namespace Inventory.BLL
{
  public  class RoleBs
    {
        private RoleDA NewRoleDA = new RoleDA();
        public IEnumerable<Role> GetAllRoles()
        {
            return NewRoleDA.GetAllRoles();
        }
    }
}
