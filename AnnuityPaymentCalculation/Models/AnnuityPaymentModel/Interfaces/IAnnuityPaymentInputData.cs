using PaymentMath.Interfaces;

namespace AnnuityPaymentCalculation.Models.AnnuityPaymentModel.Interfaces;

public interface IAnnuityPaymentInputData : IPaymentInputBase
{
    /// <summary>
    /// Номер платежа
    /// </summary>
    public int PaymentNumber { get; set; }

    /// <summary>
    /// Дата платежа
    /// </summary>
    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// Шаг платежа
    /// </summary>
    public int PaymentStep { get; set; }
    
    /// <summary>
    /// Тип платежа
    /// </summary>
    public AnnuityPayType PayType { get; set; }
}