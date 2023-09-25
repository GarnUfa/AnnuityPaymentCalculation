namespace PaymentMath.Interfaces;

public interface IPaymentOutputBase
{
    /// <summary>
    /// Номер платежа
    /// </summary>
    public int PaymentNumber { get; set; }

    /// <summary>
    /// Дата платежа
    /// </summary>
    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// Сумма платежа
    /// </summary>
    public double PaymentAmount { get; set; }
}