namespace PaymentMath.MathOperations.Annuity;

public class PaymentCalculationsAdvanced : PaymentCalculationsStandard
{

    private readonly decimal _totalPercentage;

    public PaymentCalculationsAdvanced(decimal loanAmount, int quantityPayments, int percentRate, DateTime lastPaymentDate, int paymentStep) : base(loanAmount, quantityPayments, percentRate, lastPaymentDate)
    {
        _paymentStep = paymentStep;

        _quantityPayments = quantityPayments / paymentStep;
        _percentRate = percentRate * paymentStep;
    }

    protected override void CheckingValidityInputData()
    {
        base.CheckingValidityInputData();
        if (_paymentStep > _quantityPayments)
        {
            throw new ArgumentException($"Шаг платежа не может быть больше срока займа");
        }
    }

    protected override void GetPaymentDate()
    {
        PaymentDate = _lastPaymentDate.AddDays(_paymentStep);
    }

    protected override void GetPaymentAmount()
    {
        var percentPerDayByNumerical = _totalPercentage.PercentNumerical() / _quantityPayments;

        var divider = (decimal)(Math.Pow(1 + (double)percentPerDayByNumerical, _quantityPayments)) - 1;

        PaymentAmount = _loanAmount * (percentPerDayByNumerical + (percentPerDayByNumerical / divider));
    }

}