using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace AnnuityPaymentCalculation.Services;

public static class AddErrorMessageLocalization
{
    public static void AddErrorLocalization(this IServiceCollection service)
    {
        service.AddLocalization(option => { option.ResourcesPath = "Resources"; });
        service.AddMvc(options =>
            {
                var F = service.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                var L = F.Create("ModelBindingMessages", "AnnuityPaymentCalculation");
                options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(
                    (x) => L["The value '{0}' is invalid.", x]);
                options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(
                    (x) => L["The field {0} must be a number.", x]);
                options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(
                    (x) => L["A value for the '{0}' property was not provided.", x]);
                options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor(
                    (x, y) => L["The value '{0}' is not valid for {1}.", x, y]);
                options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(
                    () => L["A value is required."]);
                options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(
                    (x) => L["The supplied value is invalid for {0}.", x]);
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                    (x) => L["Null value is invalid.", x]);
            })
            .AddDataAnnotationsLocalization()
            .AddViewLocalization();
        service.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[] { new CultureInfo("ru") };
            options.DefaultRequestCulture = new RequestCulture("ru", "ru");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });
    }
}