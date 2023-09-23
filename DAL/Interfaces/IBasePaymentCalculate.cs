using DAL.Model;
using System.ComponentModel.DataAnnotations;

namespace DAL.Interfaces;

public interface IBasePaymentCalculate
{
    /// <summary>
    /// Сумма займа
    /// </summary>
    [Display(Name = "Сумма кредитования")]
    [Required(ErrorMessage = "Введите сумму кредитования")]
    [Range(10000, 10000000, ErrorMessage = "Введите сумму от 10000 до 10000000")]
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