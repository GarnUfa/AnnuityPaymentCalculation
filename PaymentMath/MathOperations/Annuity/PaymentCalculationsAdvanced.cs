namespace PaymentMath.MathOperations.Annuity;

public class PaymentCalculationsAdvanced : PaymentCalculationsStandart
{
    public PaymentCalculationsAdvanced(decimal loanAmount, int loanTerm, int percentRate, DateTime lastPaymentDate) : base(loanAmount, loanTerm, percentRate, lastPaymentDate)
    {
        
    }
}