using PaymentMath.MathOperations.Base;

namespace PaymentMath.MathOperations.Annuity;

public interface IAnnuityPaymentCalculations : IPaymentCalculationsBase
{
    public DateTime PaymentDate { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal BalanceMainDebt { get; set; }
    public decimal PaymentAmountByPercent { get; set; }
}