using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Unico.FeiraLivre.Domain.Entities;

namespace Unico.FeiraLivre.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Feira> Feira { get; set; }       

        Task<int> SaveChangesAsync();
    }
}
