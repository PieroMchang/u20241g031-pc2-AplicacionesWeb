using PC28168.U20241G031.OpenPay.Platform.Settlements.Application.Errors;
using PC28168.U20241G031.Openpay.Platform.Settlements.Application.Services;

using PC28168.U20241G031.Openpay.Platform.Settlements.Domain.Model.Aggregates;

using PC28168.U20241G031.OpenPay.Platform.Settlements.Domain.Model.Commands;
using PC28168.U20241G031.Openpay.Platform.Settlements.Domain.Repositories;

using PC28168.U20241G031.OpenPay.Platform.Shared.Application.Patterns;
using PC28168.U20241G031.OpenPay.Platform.Shared.Domain.Repositories;

namespace PC28168.U20241G031.Openpay.Platform.Settlements.Application.Internal.CommandServices;

/// <summary>
/// Command service implementation for creating <see cref="DisbursementOrder"/> aggregates.
/// </summary>
/// <param name="disbursementOrderRepository">The disbursement order repository.</param>
/// <param name="unitOfWork">The unit of work.</param>
/// <remarks>Piero Francisco Montes Chang</remarks>
public class DisbursementOrderCommandService(
    IDisbursementOrderRepository disbursementOrderRepository,
    IUnitOfWork unitOfWork) : IDisbursementOrderCommandService
{
    public async Task<Result<DisbursementOrder, CreateDisbursementOrderError>> Handle(
        CreateDisbursementOrderCommand command,
        CancellationToken cancellationToken = default)
    {
        // Step 1: Instantiate Aggregate Root (validates Rules 2 through 12 and throws ArgumentException subclasses on failure)
        var disbursementOrder = new DisbursementOrder(command);

        // Step 2: Validate Business Rule 1 (No duplicate OrderTrackingCode)
        if (await disbursementOrderRepository.ExistsByOrderTrackingCodeAsync(
                disbursementOrder.OrderTrackingCode,
                cancellationToken))
        {
            return new Result<DisbursementOrder, CreateDisbursementOrderError>.Failure(
                CreateDisbursementOrderError.DuplicateOrderTrackingCode);
        }

        try
        {
            await disbursementOrderRepository.AddAsync(disbursementOrder);
            await unitOfWork.CompleteAsync();
            return new Result<DisbursementOrder, CreateDisbursementOrderError>.Success(disbursementOrder);
        }
        catch (Exception)
        {
            return new Result<DisbursementOrder, CreateDisbursementOrderError>.Failure(
                CreateDisbursementOrderError.UnexpectedError);
        }
    }
}