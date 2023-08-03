using DAL.Model;

namespace DAL.Interfaces;

public interface IBasePaymentCalculate
{
    /// <summary>
    /// Сумма займа
    /// </summary>
    public decimal LoanAmount { get; set; }
    /// <summary>
    /// Срок займа
    /// </summary>
    public int LoanTerm { get; set; }
    /// <summary>
    /// Ставка
    /// </summary>
    public int Rate { get; set; }
    /// <summary>
    /// Интервал расчета
    /// </summary>
    public CalculationInterval Interval { get; set; }
}