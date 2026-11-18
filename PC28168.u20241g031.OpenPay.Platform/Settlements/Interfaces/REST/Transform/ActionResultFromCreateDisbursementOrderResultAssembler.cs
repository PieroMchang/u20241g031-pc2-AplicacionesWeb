using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PC28168.U20241G031.OpenPay.Platform.Resources;
using PC28168.U20241G031.OpenPay.Platform.Settlements.Application.Errors;
using PC28168.U20241G031.Openpay.Platform.Settlements.Domain.Model.Aggregates;

using PC28168.U20241G031.OpenPay.Platform.Shared.Application.Patterns;

namespace PC28168.U20241G031.OpenPay.Platform.Settlements.Interfaces.REST.Transform;

/// <summary>
/// Assembler that transforms a <see cref="Result{TValue,TError}"/> into an HTTP <see cref="ActionResult"/>.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public static class ActionResultFromCreateDisbursementOrderResultAssembler
{
    public static ActionResult ToActionResultFromCreateDisbursementOrderResult(
        Result<DisbursementOrder, CreateDisbursementOrderError> result,
        ControllerBase controller,
        IStringLocalizer<SharedResource> localizer) =>
        result switch
        {
            Result<DisbursementOrder, CreateDisbursementOrderError>.Success success =>
                controller.StatusCode(
                    StatusCodes.Status201Created,
                    DisbursementOrderResourceFromEntityAssembler.ToResourceFromEntity(success.Value)),

            Result<DisbursementOrder, CreateDisbursementOrderError>.Failure failure =>
                failure.Error switch
                {
                    CreateDisbursementOrderError.DuplicateOrderTrackingCode =>
                        controller.Conflict(localizer["SettlementsDisbursementOrderDuplicated"].Value),

                    CreateDisbursementOrderError.UnexpectedError =>
                        controller.Problem(
                            title: localizer["UnexpectedServerError"].Value,
                            detail: localizer["UnexpectedErrorCreatingDisbursementOrder"].Value,
                            statusCode: StatusCodes.Status500InternalServerError),

                    _ => controller.Problem(
                        title: localizer["UnexpectedServerError"].Value,
                        detail: localizer["UnexpectedErrorProcessingRequest"].Value,
                        statusCode: StatusCodes.Status500InternalServerError)
                },

            _ => controller.Problem(
                title: localizer["UnexpectedServerError"].Value,
                detail: localizer["UnexpectedErrorProcessingRequest"].Value,
                statusCode: StatusCodes.Status500InternalServerError)
        };
}