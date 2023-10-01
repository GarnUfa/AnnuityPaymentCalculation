using System.ComponentModel.DataAnnotations;

namespace PaymentMath.Interfaces;

public interface IPaymentOutputBase
{

    /// <summary>
    /// Номер платежа
    /// </summary>
    [Display(Name = "Номер платежа")]
    public int PaymentNumber { get; set; }


    /// <summary>
    /// Дата платежа
    /// </summary>
    [Display(Name = "Дата платежа")]
    [DisplayFormat(DataFormatString = "{0:D}")]
    public DateTime PaymentDate { get; set; }


    /// <summary>
    /// Размер ежемесячного платежа
    /// </summary>
    [Display(Name = "Размер платежа")]
    public decimal PaymentAmount { get; set; }
}