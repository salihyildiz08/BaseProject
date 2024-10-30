using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class BaseProjectContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=IT-03;initial catalog=MyDb;integrated security=true;TrustServerCertificate=true");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
