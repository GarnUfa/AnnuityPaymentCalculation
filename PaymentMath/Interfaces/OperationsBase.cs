namespace PaymentMath.Interfaces;

public abstract class OperationsBase
{
    public abstract IPaymentOutputBase GetCalculationResult(IPaymentInputBase inputData);
}