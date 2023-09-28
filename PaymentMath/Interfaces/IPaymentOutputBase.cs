using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PaymentMath.Interfaces;

public interface IPaymentOutputBase
{
    [Display(Name = "Номер платежа")]
    /// <summary>
    /// Номер платежа
    /// </summary>
    public int PaymentNumber { get; set; }

    [Display(Name = "Дата платежа")]
    /// <summary>
    /// Дата платежа
    /// </summary>
    public DateTime PaymentDate { get; set; }

    [Display(Name = "Размер ежемесячного платежа")]
    /// <summary>
    /// Размер ежемесячного платежа
    /// </summary>
    public decimal PaymentAmount { get; set; }
}