using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.Localization;
using Microsoft.OpenApi;
using PC28168.U20241G031.OpenPay.Platform.Resources;
using PC28168.U20241G031.OpenPay.Platform.Settlements.Interfaces.REST.Resources;

namespace PC28168.U20241G031.OpenPay.Platform.Settlements.Interfaces.REST.Transform;

/// <summary>
/// OpenAPI transformer for localizing endpoint operation and schema descriptions.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public static class LocalizedOpenApiAssembler
{
    private static readonly Dictionary<string, (string Summary, string Description,
        IReadOnlyDictionary<string, string> Responses)> OperationResources =
        new Dictionary<string, (string, string, IReadOnlyDictionary<string, string>)>
        {
            ["CreateDisbursementOrder"] = (
                "CreateDisbursementOrderSummary",
                "CreateDisbursementOrderDescription",
                new Dictionary<string, string>
                {
                    ["201"] = "CreateDisbursementOrderCreated",
                    ["400"] = "CreateDisbursementOrderBadRequest",
                    ["409"] = "CreateDisbursementOrderConflict",
                    ["500"] = "CreateDisbursementOrderServerError"
                })
        };

    public static Task TransformOperationAsync(
        OpenApiOperation operation,
        OpenApiOperationTransformerContext context,
        CancellationToken cancellationToken)
    {
        if (context.Description.ActionDescriptor is not ControllerActionDescriptor action ||
            !OperationResources.TryGetValue(action.ActionName, out var resources))
            return Task.CompletedTask;

        var localizer = context.ApplicationServices.GetRequiredService<IStringLocalizer<SharedResource>>();
        operation.OperationId = action.ActionName;
        operation.Summary = localizer[resources.Summary].Value;
        operation.Description = localizer[resources.Description].Value;
        if (operation.Responses is null) return Task.CompletedTask;

        foreach (var (statusCode, resourceKey) in resources.Responses)
        {
            if (operation.Responses.TryGetValue(statusCode, out var response) &&
                response is OpenApiResponse openApiResponse)
                openApiResponse.Description = localizer[resourceKey].Value;
        }

        return Task.CompletedTask;
    }

    public static Task TransformSchemaAsync(
        OpenApiSchema schema,
        OpenApiSchemaTransformerContext context,
        CancellationToken cancellationToken)
    {
        var localizer = context.ApplicationServices.GetRequiredService<IStringLocalizer<SharedResource>>();
        var type = context.JsonTypeInfo.Type;
        if (type == typeof(CreateDisbursementOrderResource))
            schema.Description = localizer["CreateDisbursementOrderSchema"].Value;
        else if (type == typeof(DisbursementOrderResource))
            schema.Description = localizer["DisbursementOrderSchema"].Value;

        return Task.CompletedTask;
    }
}