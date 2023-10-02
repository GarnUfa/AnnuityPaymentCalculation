using PaymentMath.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AnnuityPaymentCalculation.Models.AnnuityPaymentModel.Interfaces;

public interface IAnnuityPaymentOutputData : IPaymentOutputBase
{
    /// <summary>
    /// Размер основной части платежа
    /// </summary>
    [Display(Name = "Размер основной части платежа")]
    public decimal MainPartOfPayment { get; set; }


    /// <summary>
    /// Размер процентной части платежа
    /// </summary>
    [Display(Name = "Размер процентной части платежа")]
    public decimal PercentageOfPayment { get; set; }

    /// <summary>
    /// Остаток долга
    /// </summary>
    [Display(Name = "Остаток долга")]
    public decimal DebtBalance { get; set; }
}