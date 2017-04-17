using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using Inventory.Model;

namespace Inventory.BLL
{
   public class CompanyLogoBs
    {
        private CompanyLogoDA NewCompanyLogoDA = new CompanyLogoDA();
        string message;

        public CompanyLogo GetByUsername(string username)
        {
            return NewCompanyLogoDA.GetByUsername(username);

        }

        public CompanyLogo GetCompanyLogo()
        {
            return NewCompanyLogoDA.GetCompanyLogo();

        }
        public void Insert(CompanyLogo CompanyLogoDAObj)
        {
            NewCompanyLogoDA.Insert(CompanyLogoDAObj);
        }

        public void Update(CompanyLogo CompanyLogoDAObj)
        {
            var CompanyLogoExist = NewCompanyLogoDA.GetByUsername(CompanyLogoDAObj.Username);
            CompanyLogoExist.Logo = CompanyLogoDAObj.Logo;
            CompanyLogoExist.Flag = CompanyLogoDAObj.Flag;
            NewCompanyLogoDA.Update(CompanyLogoExist);
        }

        public void Delete(string id)
        {
            NewCompanyLogoDA.Delete(id);
        }
    }
}
