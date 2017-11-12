using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Threading.Tasks;

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

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<PostCategory> PostCategories { get; set; }

        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ShipDateSetting> ShipDateSettings { get; set; }


        #region Store procs

        public async Task<IEnumerable<Product>> SearchForProduct(string term)
        {
            var searchTerm = new SqlParameter("@term", term);
            return await this.Database.SqlQuery<Product>("SearchForProduct @term", searchTerm).ToListAsync();
        }

        public async Task<IEnumerable<Post>> SearchForPostByTitle(string term)
        {
            var searchTerm = new SqlParameter("@term", term);
            return await this.Database.SqlQuery<Post>("SearchForPostByTitle @term", searchTerm).ToListAsync();
        }

        public async Task<IEnumerable<Post>> SearchForPostByContent(string term)
        {
            var searchTerm = new SqlParameter("@term", term);
            return await this.Database.SqlQuery<Post>("SearchForPostContent @term", searchTerm).ToListAsync();
        }

        #endregion

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

        //Create User=admin@abc.com with password=123123123 in the Admin role        
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
            var usermanager = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
            if(usermanager.FindByEmail("admin@abc.com") == null)
            {
                var admin = new ApplicationUser { Email = "admin@abc.com", UserName = "admin@abc.com", EmailConfirmed = true };

                var user = usermanager.Create(admin, "123123123");
                usermanager.AddToRole(admin.Id, "Admin");
            }
        }
    }
}