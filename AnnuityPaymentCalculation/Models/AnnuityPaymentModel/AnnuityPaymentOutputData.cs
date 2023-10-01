using AnnuityPaymentCalculation.Models.AnnuityPaymentModel.Interfaces;

namespace AnnuityPaymentCalculation.Models.AnnuityPaymentModel;

public class AnnuityPaymentOutputData : IAnnuityPaymentOutputData
{
   
    public DateTime PaymentDate { get; set; }
    public int PaymentNumber { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal MainPartOfPayment { get; set; }
    public decimal PercentageOfPayment { get; set; }
    public decimal DebtBalance { get; set; }
}