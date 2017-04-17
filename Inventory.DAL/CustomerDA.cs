using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;
using System.Data.Entity;

namespace Inventory.DAL
{
   public class CustomerDA
    {
        private InventoryContext context = new InventoryContext();

        public IEnumerable<Customer> GetAllCustomer()
        {
            return context.Customers.ToList();
        }

        public Customer GetById(string id)
        {
            return context.Customers.Where(c=>c.CustomerID== id).FirstOrDefault();
        }
        public void Insert(Customer CustomerDAObj)
        {
            context.Customers.Add(CustomerDAObj);
            context.SaveChanges();
        }

        public void Update(Customer CustomerDAObj)
        {

            context.Entry(CustomerDAObj).State= EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var search = context.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
            context.Customers.Remove(search);
            context.SaveChanges();
        }

        public Customer GetByPhoneNumber(string PhoneNumber)
        {

            return context.Customers.Where(c => c.CustomerPhone == PhoneNumber).Include("Transactions").FirstOrDefault();
        }

        public Customer GetByEmail(string Email)
        {
            return context.Customers.Where(c => c.EmailAddress == Email).Include("Transactions").FirstOrDefault();
        }

        public Customer GetByCustomerName(string name)
        {

            return context.Customers.Where(c => c.Surname.StartsWith(name) || c.Surname.EndsWith(name)).Include("Transactions").FirstOrDefault();
        }

        public IEnumerable<Customer> SearchCustomerByName(string name)
        {
            return context.Customers.Where(c => c.Surname.Contains(name)  ||  c.Othername.Contains(name) || c.CustomerPhone==name).ToList();
        }

        public Customer GetLastRegisteredCustomer()
        {
            return context.Customers.OrderByDescending(c=>c.Keydate).FirstOrDefault();
        }
    }
}
