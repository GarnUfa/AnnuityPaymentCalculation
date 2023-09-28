namespace PaymentMath.Interfaces;

public interface IGetResultApplicationService<out T> where T :  IPaymentOutputBase
{
    /// <summary>
    /// Возвращает результаты вычисления по платежу на основе предоставленных входных данных.
    /// </summary>
    /// <param name="inputData">Входные данные от представления.</param>
    /// <returns>Перечисление результатов вычисления.</returns>
    public IEnumerable<T> GetCalculationResult(IPaymentInputBase inputData);
}