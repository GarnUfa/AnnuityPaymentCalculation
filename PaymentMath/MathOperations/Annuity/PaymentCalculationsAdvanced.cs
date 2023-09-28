namespace PaymentMath.MathOperations.Annuity;

public class PaymentCalculationsAdvanced : PaymentCalculationsStandard
{

    private readonly decimal _totalPercentage;

    public PaymentCalculationsAdvanced(decimal initialLoanAmount, decimal loanAmount, int quantityPayments, int percentRate, DateTime lastPaymentDate, int paymentStep) : base(initialLoanAmount, quantityPayments, percentRate, lastPaymentDate, loanAmount)
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
        var percentPerDayByNumerical = _percentRate.PercentNumerical() / _quantityPayments;

        var divider = (decimal)(Math.Pow(1 + (double)percentPerDayByNumerical, _quantityPayments)) - 1;

        PaymentAmount = _initialLoanAmount * (percentPerDayByNumerical + (percentPerDayByNumerical / divider));
    }

    protected override void GetPaymentAmountByPercent()
    {
        PercentageOfPayment = _loanAmount * _percentRate.PercentNumerical() / _quantityPayments; 
    }

}