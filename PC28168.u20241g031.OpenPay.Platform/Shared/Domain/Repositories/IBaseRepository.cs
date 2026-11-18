namespace PC28168.U20241G031.OpenPay.Platform.Shared.Domain.Repositories;

/// <summary>
/// Generic base repository interface for domain entities.
/// </summary>
/// <typeparam name="TEntity">The aggregate root type.</typeparam>
/// <remarks>Piero Francisco Montes Chang</remarks>
public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task<TEntity?> FindByIdAsync(int id);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<IEnumerable<TEntity>> ListAsync();
}