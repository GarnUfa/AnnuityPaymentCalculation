using PaymentMath.MathOperations.Annuity;

namespace AnnuityStandardTests
{
    public class PaymentCalculationsStandardTest
    {


        [Fact]
        public void PaymentCalculationsStandard_Test()
        {
            var pc = new PaymentCalculationsStandard(loanAmount: 10000, quantityPayments: 6, percentRate: 10,
                lastPaymentDate: DateTime.Now);

            pc.Calculate();

        }
    }
}