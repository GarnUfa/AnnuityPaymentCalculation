using PaymentMath.MathOperations.Base;

namespace PaymentMath.MathOperations.Annuity;

public interface IAnnuityPaymentCalculations : IPaymentCalculationsBase
{
    /// <summary>
    /// Дата платежа
    /// </summary>
    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// Размер ежемесячного платежа
    /// </summary>
    public decimal PaymentAmount { get; set; }

    /// <summary>
    /// Размер основной части платежа
    /// </summary>
    public decimal MainPartOfPayment { get; set; }

    /// <summary>
    /// Размер процентной части платежа
    /// </summary>
    public decimal PercentageOfPayment { get; set; }

    /// <summary>
    /// Сумма долга после оплаты текущего платежа
    /// </summary>
    public decimal DebtAmountAfterPayment { get; set; }
}