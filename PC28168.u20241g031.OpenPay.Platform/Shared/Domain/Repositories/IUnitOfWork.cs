namespace PC28168.U20241G031.OpenPay.Platform.Shared.Domain.Repositories;

/// <summary>
/// Unit of Work contract for committing database changes.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public interface IUnitOfWork
{
    Task CompleteAsync();
}