using Microsoft.EntityFrameworkCore;
using PC28168.U20241G031.OpenPay.Platform.Shared.Domain.Repositories;
using PC28168.U20241G031.Openpay.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using PC28168.U20241G031.OpenPay.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace PC28168.U20241G031.OpenPay.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Generic Entity Framework Core base repository implementation.
/// </summary>
/// <typeparam name="TEntity">The aggregate root entity type.</typeparam>
/// <param name="context">The database context.</param>
/// <remarks>Piero Francisco Montes Chang</remarks>
public class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext Context = context;

    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }
}