namespace PaymentMath.Interfaces;

public interface IPaymentInputBase
{
    /// <summary>
    /// Сумма займа
    /// </summary>
    public int LoanAmount { get; set; }

    /// <summary>
    /// Срок займа
    /// </summary>
    public int LoanTerm { get; set;}

    /// <summary>
    /// Процентная ставка
    /// </summary>
    public int Rate { get; set; }
}