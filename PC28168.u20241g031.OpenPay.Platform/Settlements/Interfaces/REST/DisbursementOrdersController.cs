using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PC28168.U20241G031.OpenPay.Platform.Resources;
using PC28168.U20241G031.Openpay.Platform.Settlements.Application.Services;

using PC28168.U20241G031.OpenPay.Platform.Settlements.Interfaces.REST.Resources;
using PC28168.U20241G031.OpenPay.Platform.Settlements.Interfaces.REST.Transform;

namespace PC28168.U20241G031.Openpay.Platform.Settlements.Interfaces.REST;

/// <summary>
/// RESTful API controller for managing Disbursement Orders (/api/v1/disbursement-orders).
/// </summary>
/// <param name="disbursementOrderCommandService">The disbursement order command service.</param>
/// <param name="localizer">The string localizer for i18n responses.</param>
/// <param name="logger">The diagnostic logger.</param>
/// <remarks>Piero Francisco Montes Chang</remarks>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Disbursement Orders")]
public class DisbursementOrdersController(
    IDisbursementOrderCommandService disbursementOrderCommandService,
    IStringLocalizer<SharedResource> localizer,
    ILogger<DisbursementOrdersController> logger)
    : ControllerBase
{
    /// <summary>
    /// Registers a new DisbursementOrder.
    /// </summary>
    /// <param name="resource">The request body containing primitive attributes of the disbursement order.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>HTTP 201 Created with the created resource, HTTP 400 Bad Request on validation error, or HTTP 409 Conflict on duplicate.</returns>
    /// <remarks>Piero Francisco Montes Chang</remarks>
    [HttpPost]
    [ProducesResponseType(typeof(DisbursementOrderResource), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CreateDisbursementOrder(
        [FromBody] CreateDisbursementOrderResource resource,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = CreateDisbursementOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await disbursementOrderCommandService.Handle(command, cancellationToken);
            return ActionResultFromCreateDisbursementOrderResultAssembler
                .ToActionResultFromCreateDisbursementOrderResult(result, this, localizer);
        }
        catch (ArgumentException ex)
        {
            logger.LogWarning(ex,
                "Domain validation failed while creating DisbursementOrder for OrderTrackingCode {OrderTrackingCode}",
                resource.OrderTrackingCode);
            var localizedMessage = string.Format(localizer["InvalidDisbursementOrderRequest"].Value, ex.Message);
            return BadRequest(localizedMessage);
        }
        catch (Exception ex)
        {
            logger.LogError(ex,
                "Unexpected error while creating DisbursementOrder for OrderTrackingCode {OrderTrackingCode}",
                resource.OrderTrackingCode);

            return Problem(
                title: localizer["UnexpectedServerError"].Value,
                detail: localizer["UnexpectedErrorCreatingDisbursementOrder"].Value,
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}