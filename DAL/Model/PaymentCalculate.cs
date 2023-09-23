using System.ComponentModel.DataAnnotations;
using DAL.Interfaces;

namespace DAL.Model;

public class PaymentCalculate : IBasePaymentCalculate, IExtendedPaymentCalculate
{
    public decimal LoanAmount { get; set; }
    public int LoanTerm { get; set; }
    public int Rate { get; set; }
    public CalculationInterval Interval { get; set; }
    public int PaymentStep { get; set; }
}