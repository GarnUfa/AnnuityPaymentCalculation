using PaymentMath.MathOperations.Base;

namespace PaymentMath.MathOperations.Annuity;

public class PaymentCalculationsStandart : PaymentCalculationsBase, IAnnuityPaymentCalculations
{
    protected readonly decimal _loanAmount;
    protected readonly int _loanTerm;
    protected readonly decimal _percentRate;
    protected readonly DateTime _lastPaymentDate;
    protected readonly int _paymentStep = 1;

    public DateTime PaymentDate { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal BalanceMainDebt { get; set; }
    public decimal PaymentAmountByPercent { get; set; }

    /// <summary>
    /// Калькулятор платежа
    /// </summary>
    /// <param name="loanAmount">Сумма долга на момент платежа</param>
    /// <param name="loanTerm">Срок займа</param>
    /// <param name="percentRate">Процентная ставка</param>
    /// <param name="lastPaymentDate">Дата последнего платежа</param>
    public PaymentCalculationsStandart(decimal loanAmount, int loanTerm, decimal percentRate, DateTime lastPaymentDate)
    {
        _loanAmount = loanAmount;
        _loanTerm = loanTerm;
        _percentRate = percentRate;
        _lastPaymentDate = lastPaymentDate;
    }

    protected sealed override void CheckingValidityInputData()
    {
        if (_loanAmount <= 0 || _loanTerm <= 0 || _percentRate <= 0)
        {
            throw new ArgumentException($"Входящие данные не могут быть меньше или равны нулю");
        }
    }

    public virtual void Calculate()
    {
        CheckingValidityInputData();
        GetPaymentDate();
        GetPaymentAmount();
        GetPaymentAmountByPercent();
        GetBalanceMainDebt();
    }

    /// <summary>
    /// Просчитывает следущую дату платежа
    /// </summary>
    protected virtual void GetPaymentDate()
    {
        PaymentDate = _lastPaymentDate.AddMonths(_paymentStep);
    }

    /// <summary>
    /// Просчитывает размер платежа
    /// </summary>
    protected virtual void GetPaymentAmount()
    {
        var percentPerMonthByNumerical = _percentRate.PercentNumerical().ByMonth();
        var divider = (decimal)(Math.Pow(1 + (double)percentPerMonthByNumerical, _loanTerm)) - 1;

        PaymentAmount = _loanAmount * (percentPerMonthByNumerical + (percentPerMonthByNumerical / divider));
    }

    /// <summary>
    /// Основной долг
    /// </summary>
    protected virtual void GetBalanceMainDebt()
    {
        BalanceMainDebt = PaymentAmount - PaymentAmountByPercent;
    }

    /// <summary>
    /// Размер процентной части платежа
    /// </summary>
    public virtual void GetPaymentAmountByPercent()
    {
        PaymentAmountByPercent = _loanAmount * _percentRate.PercentNumerical().ByMonth();
    }
}