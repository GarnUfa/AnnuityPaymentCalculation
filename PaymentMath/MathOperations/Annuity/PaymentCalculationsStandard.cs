using PaymentMath.MathOperations.Base;

namespace PaymentMath.MathOperations.Annuity;

public class PaymentCalculationsStandard : PaymentCalculationsBase, IAnnuityPaymentCalculations
{
    protected readonly decimal _loanAmount;
    protected int _quantityPayments;
    protected decimal _percentRate;
    protected readonly DateTime _lastPaymentDate;
    protected int _paymentStep = 1;

    /// <summary>
    /// Дата платежа
    /// </summary>
    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// Размер ежемесячного платежа
    /// </summary>
    public decimal PaymentAmount { get; set; }

    /// <summary>
    /// Размер основной части долга
    /// </summary>
    public decimal BalanceMainDebt { get; set; }

    /// <summary>
    /// Размер процентной части долга
    /// </summary>
    public decimal PaymentAmountByPercent { get; set; }

    /// <summary>
    /// Калькулятор платежа
    /// </summary>
    /// <param name="loanAmount">Сумма долга на момент платежа</param>
    /// <param name="quantityPayments">Срок займа \ Количество платежей</param>
    /// <param name="percentRate">Процентная ставка</param>
    /// <param name="lastPaymentDate">Дата последнего платежа</param>
    public PaymentCalculationsStandard(decimal loanAmount, int quantityPayments, decimal percentRate, DateTime lastPaymentDate)
    {
        _loanAmount = loanAmount;
        _quantityPayments = quantityPayments;
        _percentRate = percentRate;
        _lastPaymentDate = lastPaymentDate;
    }

    protected override void CheckingValidityInputData()
    {
        if (_loanAmount <= 0 || _quantityPayments <= 0 || _percentRate <= 0)
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
    /// Просчитывает дату платежа
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
        var divider = (decimal)(Math.Pow(1 + (double)percentPerMonthByNumerical, _quantityPayments)) - 1;

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
    protected virtual void GetPaymentAmountByPercent()
    {
        PaymentAmountByPercent = _loanAmount * _percentRate.PercentNumerical().ByMonth();
    }
}