using AnnuityPaymentCalculation.Models.AnnuityPaymentModel.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AnnuityPaymentCalculation.Models.AnnuityPaymentModel;

public class AnnuityPaymentInputData : IAnnuityPaymentInputData
{
    [Display(Name = "Сумма кредитования")]
    [Required(ErrorMessage = "Введите сумму кредитования")]
    [Range(10000, 10000000, ErrorMessage = "Введите сумму от 10000 до 10000000")]
    public decimal LoanAmount { get; set; }

    [Display(Name = "Срок кредитования в месяцах")]
    [Required(ErrorMessage = "Введите срок кредитования")]
    [Range(6, 600, ErrorMessage = "Введите срок кредитования от 6 до 600")]
    public int LoanTerm { get; set; }

    [Display(Name = "Процентная ставка")]
    [Required(ErrorMessage = "Введите процентную ставку")]
    [Range(1, 100, ErrorMessage = "Неверная процентная ставка")]
    public int Rate { get; set; }
    public int PaymentNumber { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    public int PaymentStep { get; set; }
}