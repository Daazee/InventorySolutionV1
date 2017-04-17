using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;
using System.Data.Entity;

namespace Inventory.DAL
{
    public class UserDA
    {
        public InventoryContext context = new InventoryContext();
        private string message;
        //public IEnumerable<User> ListAll1()
        //{
        //    return context.Users.Where(c=>c.Reg_Status !="AD").ToList(); // to not include admin

        //}

        public IEnumerable<User> ListAll()
        {
            return context.Users.Include("Role").ToList(); 

        }


        public IEnumerable<User> ListAllByStatus(int status)
        {
            return context.Users.Where(c=>c.Status==status).Include("Role").ToList();
        }

        public string UpdateStatus(string username, int status)
        {
            var search = context.Users.Where(c => c.Username == username).FirstOrDefault();
            search.Status = status;
            context.SaveChanges();
            message = "Status updated successfully";
            return message;
        }
        public User GetById(int id)
        {
            return context.Users.Where(c => c.UserID == id).Include("Role").FirstOrDefault();
        }

        public User GetByUsername(string username)
        {
            return context.Users.Where(c => c.Username == username).FirstOrDefault();

        }
        public string VerifyUsername(string username)
        {
            var search= context.Users.Where(c => c.Username == username).FirstOrDefault();
            if (search!=null)
            {
                message = "Username already exist";
            }
            else
            {
                message = "";
            }
            return message;
        }
        public void Insert(User UserDAObj)
        {
            context.Users.Add(UserDAObj);
            context.SaveChanges();
        }

        public void Update(User UserDAObj)
        {
            context.Entry(UserDAObj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var search = context.Users.Where(c => c.Username == id).FirstOrDefault();
            context.Users.Remove(search);
            context.SaveChanges();
        }

        public bool Login(string username, string password)
        {
            bool result=false;
            var search = context.Users.Where(c => c.Username == username && c.Password==password).FirstOrDefault();
            if(search!=null)
            {
                result = true;
            }
            return result;
        }

        public User LoginNew(string username)
        {
            
            var search = context.Users.Where(c => c.Username == username).FirstOrDefault();
            return search;
           
        }
    }
}
