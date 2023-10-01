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
        var numberOfPayments = input.LoanTerm / input.PaymentStep;

        var lastPay = new AnnuityPaymentOutputData();

        if (input.PayType == AnnuityPayType.Standard)
        {
            for (var i = 1; i <= numberOfPayments; i++)
            {
                var outputData = CalculateStandardPay(i, input, lastPay);
                result.Add(outputData);
                lastPay = (AnnuityPaymentOutputData)outputData;
            }
        }
        else
        {
            for (var i = 1; i <= numberOfPayments; i++)
            {
                var outputData = CalculateAdvancedPay(i, input, lastPay);
                result.Add(outputData);
                lastPay = (AnnuityPaymentOutputData)outputData;
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
            lastPaymentDate:    lastPayOutputData.PaymentDate,
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

    /// <summary>
    /// Подсчет платежа с шагом в равным primaryInputData.PaymentStep, со ставкой в день
    /// </summary>
    /// <param name="paymentNumber">Номер платежа</param>
    /// <param name="primaryInputData">Основные входные данные для подсчета платежа</param>
    /// <param name="lastPayOutputData">Данные о прошлом платеже</param>
    /// <returns></returns>
    private IAnnuityPaymentOutputData CalculateAdvancedPay(int paymentNumber, IAnnuityPaymentInputData primaryInputData, IAnnuityPaymentOutputData lastPayOutputData)
    {
        var calculate = new PaymentCalculationsAdvanced(
            initialLoanAmount: primaryInputData.LoanAmount,
            quantityPayments: primaryInputData.LoanTerm,
            percentRate: primaryInputData.Rate,
            lastPaymentDate: primaryInputData.PaymentDate,
            loanAmount: lastPayOutputData.DebtBalance,
            paymentStep: primaryInputData.PaymentStep
        );

        calculate.Calculate();

        return new AnnuityPaymentOutputData()
        {
            PaymentNumber = paymentNumber,
            PaymentDate = calculate.PaymentDate,
            PaymentAmount = calculate.PaymentAmount,
            DebtBalance = calculate.DebtAmountAfterPayment,
            MainPartOfPayment = calculate.MainPartOfPayment,
            PercentageOfPayment = calculate.PercentageOfPayment,
        };
    }
}