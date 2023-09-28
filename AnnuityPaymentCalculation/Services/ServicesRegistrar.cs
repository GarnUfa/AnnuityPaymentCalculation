using AnnuityPaymentCalculation.Models.AnnuityPaymentModel.Interfaces;
using AnnuityPaymentCalculation.Services.PaymentsCalculations.AnnuityPayment;
using PaymentMath.Interfaces;

namespace AnnuityPaymentCalculation.Services;

public static class ServicesRegistrar
{
    public static void AddCalculationsServices(this IServiceCollection services)
        => services.AddTransient<IGetResultApplicationService<IAnnuityPaymentOutputData>, GetAnnuityResult>();
}