using mediatR.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace mediatR.Business.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }
        DbSet<Company> Companies { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
