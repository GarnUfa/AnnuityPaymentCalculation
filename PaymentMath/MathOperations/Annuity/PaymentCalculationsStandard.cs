using PaymentMath.MathOperations.Base;

namespace PaymentMath.MathOperations.Annuity;

public class PaymentCalculationsStandard : PaymentCalculationsBase, IAnnuityPaymentCalculations
{
    protected readonly decimal _initialLoanAmount;
    protected readonly decimal _loanAmount;
    protected int _quantityPayments;
    protected decimal _percentRate;
    protected readonly DateTime _lastPaymentDate;
    protected int _paymentStep = 1;
    
    public DateTime PaymentDate { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal MainPartOfPayment { get; set; }
    public decimal PercentageOfPayment { get; set; }
    public decimal DebtAmountAfterPayment { get; set; }

    /// <summary>
    /// Калькулятор платежа
    /// </summary>
    /// <param name="initialLoanAmount">Первоначальная сумма кредита</param>
    /// <param name="quantityPayments">Срок займа \ Количество платежей</param>
    /// <param name="percentRate">Процентная ставка</param>
    /// <param name="lastPaymentDate">Дата последнего платежа</param>
    /// <param name="loanAmount">Сумма долга на момент платежа</param>
    public PaymentCalculationsStandard(decimal initialLoanAmount, int quantityPayments, int percentRate,
        DateTime lastPaymentDate, decimal loanAmount = 0)
    {
        _initialLoanAmount = initialLoanAmount;
        _loanAmount = loanAmount <= 0 ? initialLoanAmount : loanAmount;
        _quantityPayments = quantityPayments;
        _percentRate = percentRate;
        _lastPaymentDate = lastPaymentDate;
    }

    protected override void CheckingValidityInputData()
    {
        if (_quantityPayments <= 0 || _percentRate <= 0 || _initialLoanAmount <= 0)
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
        GetDebtAmountAfterPayment();
    }

    /// <summary>
    /// Просчитывает дату платежа
    /// </summary>
    protected virtual void GetPaymentDate()
    {
        var resultDate = _lastPaymentDate == DateTime.MinValue ? DateTime.Now : _lastPaymentDate;
        PaymentDate = resultDate.AddMonths(_paymentStep);
    }

    /// <summary>
    /// Просчитывает размер платежа
    /// </summary>
    protected virtual void GetPaymentAmount()
    {
        var percentPerMonthByNumerical = _percentRate.PercentNumerical().ByMonth();
        var divider = (decimal)(Math.Pow(1 + (double)percentPerMonthByNumerical, _quantityPayments)) - 1;

        PaymentAmount = _initialLoanAmount * (percentPerMonthByNumerical + (percentPerMonthByNumerical / divider));
    }

    /// <summary>
    /// Основной долг
    /// </summary>
    protected virtual void GetBalanceMainDebt()
    {
        MainPartOfPayment = PaymentAmount - PercentageOfPayment;
    }

    /// <summary>
    /// Размер процентной части платежа
    /// </summary>
    protected virtual void GetPaymentAmountByPercent()
    {
        PercentageOfPayment = _loanAmount * _percentRate.PercentNumerical().ByMonth();
    }

    /// <summary>
    /// Сумма долга после платежа
    /// </summary>
    protected virtual void GetDebtAmountAfterPayment()
    {
        DebtAmountAfterPayment = _loanAmount - MainPartOfPayment;
    }
}