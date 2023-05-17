using Chandigarh_Estates;
using Microsoft.EntityFrameworkCore;

namespace Chandigarh_estates_web.Models
{
    
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }
            public DbSet<Login_Page> Logins { get; set; }
            public DbSet<Registration_Table> Details { get; set; }
            public DbSet<Country_Table> Countries { get; set; }
            public DbSet<State_Table> States { get; set; }
            public DbSet<City_Table> Cities { get; set; }
            public DbSet<CompanyDetail> Companies { get; set; }
            public DbSet<manageCustomer> Customers { get; set; }
            public DbSet<StoreModel> StoreModels { get; set; }
            public DbSet<CustomerVM> CustomersVM { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Login_Page>().ToTable("Login");
                modelBuilder.Entity<Registration_Table>().ToTable("Registration_Table");
                modelBuilder.Entity<Country_Table>().ToTable("Country_Table");
                modelBuilder.Entity<State_Table>().ToTable("State_Table");
                modelBuilder.Entity<City_Table>().ToTable("City_Table");
                modelBuilder.Entity<CompanyDetail>().ToTable("CompanyDetail");
                modelBuilder.Entity<StoreModel>().HasNoKey();
                modelBuilder.Entity<CustomerVM>().HasNoKey();
                modelBuilder.Entity<manageCustomer>().ToTable("ManageCustomer");
        }

        }

    
}
