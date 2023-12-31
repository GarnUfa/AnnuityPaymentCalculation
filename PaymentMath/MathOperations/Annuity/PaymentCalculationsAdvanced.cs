﻿namespace PaymentMath.MathOperations.Annuity;

public class PaymentCalculationsAdvanced : PaymentCalculationsStandard
{
    /// <summary>
    /// Минимальное соотношения шага к сроку платежа
    /// </summary>
    private const int MinStepToDateRatio = 1;

    public PaymentCalculationsAdvanced(decimal initialLoanAmount, decimal loanAmount, int quantityPayments, int percentRate, DateTime lastPaymentDate, int paymentStep) : base(initialLoanAmount, quantityPayments, percentRate, lastPaymentDate, loanAmount)
    {
        _paymentStep = paymentStep;

        _quantityPayments = quantityPayments / paymentStep;
        _percentRate = percentRate * paymentStep;
    }

    protected override void CheckingValidityInputData()
    {
        base.CheckingValidityInputData();
        if (_quantityPayments < MinStepToDateRatio)
        {
            throw new ArgumentException($"Шаг платежа не может быть больше срока займа");
        }
    }

    protected override void GetPaymentDate()
    {
        var resultDate = _lastPaymentDate == DateTime.MinValue ? DateTime.Now : _lastPaymentDate;
        PaymentDate = resultDate.AddDays(_paymentStep);
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