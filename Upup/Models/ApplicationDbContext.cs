using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Upup.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public IDbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }
    }

    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

            var roleNames = new string[] { "Customer", "Admin", "Editor" };

            foreach (var roleName in roleNames)
            {
                //Create Roles if it does not exist
                var role = roleManager.FindByName(roleName);
                if (role == null)
                {
                    roleManager.Create(new IdentityRole(roleName));
                }
            }
        }
    }
}