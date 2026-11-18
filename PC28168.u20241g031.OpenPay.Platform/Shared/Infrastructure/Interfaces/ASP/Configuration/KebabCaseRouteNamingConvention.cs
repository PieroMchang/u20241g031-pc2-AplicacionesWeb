using Microsoft.AspNetCore.Mvc.ApplicationModels;
using PC28168.U20241G031.OpenPay.Platform.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

namespace PC28168.U20241G031.OpenPay.Platform.Shared.Infrastructure.Interfaces.ASP.Configuration;

/// <summary>
/// Convention that transforms controller route templates into kebab-case.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
    {
        return selector.AttributeRouteModel != null
            ? new AttributeRouteModel
            {
                Template = selector.AttributeRouteModel.Template?.Replace("[controller]", name.ToKebabCase())
            }
            : null;
    }

    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors)
        {
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        }

        foreach (var selector in controller.Actions.SelectMany(a => a.Selectors))
        {
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        }
    }
}