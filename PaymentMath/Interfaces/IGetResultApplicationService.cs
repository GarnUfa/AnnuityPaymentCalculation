namespace PaymentMath.Interfaces;

internal interface IGetResultApplicationService
{
    public IPaymentOutputBase GetCalculationResult(IPaymentInputBase inputData);
}