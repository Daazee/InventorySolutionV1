using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Inventory.Model;


namespace Inventory.DAL
{
   public  class InventoryContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<ProductCategory> ProductCategory { get; set; }

        public DbSet<ProductDetail> ProductDetails { get; set; }

        public DbSet<Sales> Sales { get; set; }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }


        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Codes> Code { get; set; }

        public DbSet<CompanyDetail> CompanyDetails { get; set; }

        public DbSet<CompanyLogo> CompanyLogos { get; set; }

        public DbSet<StockHistory> StockHistory { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<EmailSetting> EmailSettings { get; set; }

        public DbSet<Role> Roles { get; set; }


    }
}
