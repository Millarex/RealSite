using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealSite.Application.Interfaces;
using RealSite.Domain;
using RealSite.Persistance.Data;

namespace RealSite.Persistance
{
    public class RealSiteDbContext : IdentityDbContext<UserModel>, IRealSiteDbContext
    {
        public DbSet<ManufactureModel> Manufactures { get; set; }
        public DbSet<MachineModel> Machines { get; set; }
        public DbSet<ImageModel> Images { get; set; }

        public RealSiteDbContext(DbContextOptions<RealSiteDbContext> options)
           : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Add default user Roles
            //Add default Admin user & pass
            base.OnModelCreating(builder);
        }

    }
}
