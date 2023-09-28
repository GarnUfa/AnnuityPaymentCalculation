namespace PaymentMath.Interfaces;

public interface IGetResultApplicationService<out T> where T :  IPaymentOutputBase
{
    public IEnumerable<T> GetCalculationResult(IPaymentInputBase inputData);
}