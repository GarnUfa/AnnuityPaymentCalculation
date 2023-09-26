using PaymentMath.Interfaces;

namespace AnnuityStandardTests;

public class AnnuityPaymentOutput : IPaymentOutputBase
{
    public int PaymentNumber { get; set; }
    public DateTime PaymentDate { get; set; }
    public double PaymentAmount { get; set; }
    public decimal BalanceMainDebt { get; set; }
    public decimal PaymentAmountByPercent { get; set; }
}