using Microsoft.EntityFrameworkCore;
using RealSite.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace RealSite.Application.Interfaces
{
    public interface IRealSiteDbContext
    {
        DbSet<ManufactureModel> Manufactures { get; set; }
        DbSet<MachineModel> Machines { get; set; }
        DbSet<ImageModel> Images { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
