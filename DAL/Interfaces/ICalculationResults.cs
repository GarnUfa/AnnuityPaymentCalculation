using DAL.Model;

namespace DAL.Interfaces;

public interface ICalculationResults<T> where T : IBasePaymentCalculate
{
    /// <summary>
    /// Номер платежа.
    /// </summary>
    public int PaymentId { get; set; }
    /// <summary>
    /// Дата платежа
    /// </summary>
    public DateTime PaymentDate { get; set; }
    /// <summary>
    /// Размер основного тела платежа
    /// </summary>
    public int PaymentAmountByBody { get; set; }
    /// <summary>
    /// Размер процентов в платеже
    /// </summary>
    public decimal PercentOnDebt { get; set; }
    /// <summary>
    /// Остаток основного долга после платежа
    /// </summary>
    public decimal BalanceOfDebt { get; set; }
    /// <summary>
    /// Размер платежа
    /// </summary>
    public decimal PaymentAmount { get; set; }
    /// <summary>
    /// К какому расчету относится
    /// </summary>
    public T Payment { get; set; }
}