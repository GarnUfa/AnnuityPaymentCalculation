using AnnuityPaymentCalculation.Models.AnnuityPaymentModel.Interfaces;
using AnnuityPaymentCalculation.Models.AnnuityPaymentModel.Validations;
using System.ComponentModel.DataAnnotations;

namespace AnnuityPaymentCalculation.Models.AnnuityPaymentModel;

public class AnnuityPaymentInputData : IAnnuityPaymentInputData
{
    [Display(Name = "Сумма кредитования")]
    [Required(ErrorMessage = "Введите сумму кредитования")]
    [Range(typeof(decimal), "1000,0", "10000000,0", ErrorMessage = "Введите сумму от 1000 до 10000000")]
    public decimal LoanAmount { get; set; }

    [Display(Name = "Срок кредитования")]
    [Required(ErrorMessage = "Введите срок кредитования")]
    [Range(1, 600, ErrorMessage = "Введите срок кредитования от 1 до 600")]
    [RequiredIf($"{nameof(LoanTerm)}>={nameof(PaymentStep)}", "Шаг платежа не может быть больше количества платежей")]
    public int LoanTerm { get; set; }

    [Display(Name = "Процентная ставка")]
    [Required(ErrorMessage = "Введите процентную ставку")]
    [Range(1, 100, ErrorMessage = "Неверная процентная ставка")]
    public int Rate { get; set; }

    [RequiredIf($"{nameof(LoanTerm)}>={nameof(PaymentStep)}", "Шаг платежа не может быть больше количества платежей")]
    public int PaymentStep { get; set; } = 1;

    public AnnuityPayType PayType { get; set; }
    public int PaymentNumber { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.Now;
}