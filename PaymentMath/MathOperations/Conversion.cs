namespace PaymentMath.MathOperations;

public static class Converting
{
    public static decimal ByMonth(this decimal percent) => (percent / 12);
    public static decimal PercentNumerical(this decimal percent) => (percent / 100);
    public static decimal Round(this decimal roundDecimal, int i) => Math.Round((decimal)roundDecimal, i);

}