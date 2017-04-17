namespace Inventory.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Inventory.Model;
    internal sealed class Configuration : DbMigrationsConfiguration<Inventory.DAL.InventoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Inventory.DAL.InventoryContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Inventory.DAL.InventoryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            User UserObj = new User();
            UserObj.Surname = "Administrator";
            UserObj.Othername = "Administrator";
            UserObj.Sex = "Male";
            UserObj.PhoneNumber = "07053900429";
            UserObj.Address = "TBA";
            UserObj.Username = "admin";
            UserObj.Password = "admin";
            UserObj.Status = 1;
            UserObj.RoleID = 1;
            UserObj.Flag = "A";
            UserObj.Keydate = DateTime.Now;
            context.Users.AddOrUpdate(c => c.Username, UserObj);


            CompanyDetail CompanyDetailObj = new CompanyDetail();
            CompanyDetailObj.CompanyCode = "Test";
            CompanyDetailObj.CompanyName = "Test Inventory";
            CompanyDetailObj.CompanyShortName = "Test Inventory";
            CompanyDetailObj.CompanyAddress = "Lagos";
            CompanyDetailObj.CompanyPhone1 = "07053900429";
            CompanyDetailObj.CompanyPhone2 = "07053900429";
            CompanyDetailObj.CompanyEmail = "test@yahoo.com";
            CompanyDetailObj.CompanyUsername = "admin";
            CompanyDetailObj.CompanyPassword = "admin";
            CompanyDetailObj.Flag = "A";
            CompanyDetailObj.CreatedOn = DateTime.Now;
            CompanyDetailObj.CreatedBy = "admin";
            CompanyDetailObj.ModifiedOn = DateTime.Now;
            CompanyDetailObj.ModifiedBy = "admin";
            context.CompanyDetails.AddOrUpdate(c => c.CompanyUsername, CompanyDetailObj);

            context.Roles.AddOrUpdate(
             p => p.RoleName,
             new Role { RoleName = "Administrator", Status = 1, CreatedBy = "System", CreatedOn = DateTime.Today, ModifiedBy= "System", ModifiedOn = DateTime.Today},
             new Role { RoleName = "User", Status = 1, CreatedBy = "System", CreatedOn = DateTime.Today, ModifiedBy = "System", ModifiedOn = DateTime.Today }
             );

            //
        }
    }
}
