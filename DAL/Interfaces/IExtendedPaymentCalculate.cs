namespace DAL.Interfaces;

public interface IExtendedPaymentCalculate : IBasePaymentCalculate
{
    /// <summary>
    /// Шаг платежа
    /// </summary>
    public int PaymentStep { get; set; }
}