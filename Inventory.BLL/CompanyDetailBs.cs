using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;
using Inventory.DAL;

namespace Inventory.BLL
{
  public  class CompanyDetailBs
    {
        private CompanyDetailDA NewCompanyDetailDA = new CompanyDetailDA();

        public IEnumerable<CompanyDetail> ListAll()
        {
            return NewCompanyDetailDA.ListAll();
        }

        //Use this for company details
        public CompanyDetail GetCompanyDetail()
        {
            return NewCompanyDetailDA.GetCompanyDetail();
        }
        public CompanyDetail GetById(int id)
        {
            return NewCompanyDetailDA.GetById(id);
        }
        
              public IEnumerable<CompanyDetail> GetByIdList(int id)
        {
            return NewCompanyDetailDA.GetByIdList(id);
        }

        //For sales report purpose
        public IEnumerable<CompanyDetail> GetCompanyDetailList()
        {
            return NewCompanyDetailDA.GetCompanyDetailList();
        }
        public CompanyDetail GetByCompCode(string code_type)
        {
            return NewCompanyDetailDA.GetByCompCode(code_type);
        }
        public void Insert(CompanyDetail CompanyDetailObj)
        {
            NewCompanyDetailDA.Insert(CompanyDetailObj);
        }

        public void Update(CompanyDetail CompanyDetailObj)
        {
            var CompanyDetailExist= NewCompanyDetailDA.GetById(CompanyDetailObj.CompanyID);
            CompanyDetailExist.CompanyName = CompanyDetailObj.CompanyName;
            CompanyDetailExist.CompanyShortName = CompanyDetailObj.CompanyShortName;
            CompanyDetailExist.CompanyAddress = CompanyDetailObj.CompanyAddress;
            CompanyDetailExist.CompanyPhone1 = CompanyDetailObj.CompanyPhone1;
            CompanyDetailExist.CompanyPhone2 = CompanyDetailObj.CompanyPhone2;
            CompanyDetailExist.CompanyEmail = CompanyDetailObj.CompanyEmail;
            CompanyDetailExist.Flag = CompanyDetailObj.Flag;
            CompanyDetailExist.ModifiedBy = CompanyDetailObj.ModifiedBy;
            CompanyDetailExist.ModifiedOn = DateTime.Today;
            NewCompanyDetailDA.Update(CompanyDetailExist);
        }
        public string VerifyCompanyEmail(string email)
        {
            return NewCompanyDetailDA.VerifyCompanyEmail(email);
        }

        public string DisplayCompanyShortName()
        {
            CompanyDetailBs NewCompanyDetailBs = new CompanyDetailBs();
            var result = NewCompanyDetailBs.ListAll();
            string CompanyShortName = "";
            if (result != null)
            {
                foreach (var item in result)
                {
                    CompanyShortName = item.CompanyShortName;
                }
                if (CompanyShortName != null)
                {
                    return CompanyShortName;
                }
            }
            return CompanyShortName;
        }

        public string DisplayCompanyName()
        {
            CompanyDetailBs NewCompanyDetailBs = new CompanyDetailBs();
            var result = NewCompanyDetailBs.ListAll();
            string CompanyName = "";
            if (result != null)
            {
                foreach (var item in result)
                {
                    CompanyName = item.CompanyName.ToUpper();
                }
                if (CompanyName != null)
                {
                    return CompanyName;
                }
            }
            return CompanyName;
        }
    }
}

