using AnnuityPaymentCalculation.Models.AnnuityPaymentModel;
using AnnuityPaymentCalculation.Models.AnnuityPaymentModel.Interfaces;
using PaymentMath.Interfaces;
using PaymentMath.MathOperations.Annuity;

namespace AnnuityPaymentCalculation.Services.PaymentsCalculations.AnnuityPayment;

public class GetAnnuityResult : IGetResultApplicationService<IAnnuityPaymentOutputData>
{
    public IEnumerable<IAnnuityPaymentOutputData> GetCalculationResult(IPaymentInputBase inputData)
    {
        var input = (AnnuityPaymentInputData)inputData;
        var result = new List<IAnnuityPaymentOutputData>();

        if (input.PaymentStep == 0)
        {
            var lastPay = new AnnuityPaymentOutputData();

            for (var i = 1; i <= inputData.LoanTerm; i++)
            {
                var p = CalculateStandardPay(i, input, lastPay);
                result.Add(p);
                lastPay = (AnnuityPaymentOutputData)p;
            }
        }

        return result;
    }

    /// <summary>
    /// Подсчет платежа с шагом в месяц, со ставкой в год
    /// </summary>
    /// <param name="paymentNumber">Номер платежа</param>
    /// <param name="primaryInputData">Основные входные данные для подсчета платежа</param>
    /// <param name="lastPayOutputData">Данные о прошлом платеже</param>
    /// <returns></returns>
    private IAnnuityPaymentOutputData CalculateStandardPay(int paymentNumber, IAnnuityPaymentInputData primaryInputData, IAnnuityPaymentOutputData lastPayOutputData)
    {
        var calculate = new PaymentCalculationsStandard(
            initialLoanAmount:  primaryInputData.LoanAmount,
            quantityPayments:   primaryInputData.LoanTerm,
            percentRate:        primaryInputData.Rate,
            lastPaymentDate:    primaryInputData.PaymentDate,
            loanAmount:         lastPayOutputData.DebtBalance
        );

        calculate.Calculate();

        return new AnnuityPaymentOutputData()
        {
            PaymentNumber =         paymentNumber,
            PaymentDate =           calculate.PaymentDate,
            PaymentAmount =         calculate.PaymentAmount,
            DebtBalance =           calculate.DebtAmountAfterPayment,
            MainPartOfPayment =     calculate.MainPartOfPayment,
            PercentageOfPayment =   calculate.PercentageOfPayment,
        };
    }
}