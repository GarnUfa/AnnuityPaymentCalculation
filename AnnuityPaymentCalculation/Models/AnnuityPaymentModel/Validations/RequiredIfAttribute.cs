using System.ComponentModel.DataAnnotations;
using System.Linq.Dynamic.Core;

namespace AnnuityPaymentCalculation.Models.AnnuityPaymentModel.Validations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
public class RequiredIfAttribute : ValidationAttribute
{
    private readonly string _condition;
    private readonly string _errorMessage;

    public RequiredIfAttribute(string condition, string errorMessage)
    {
        _condition = condition;
        _errorMessage = errorMessage;
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var conditionFunction = CreateExpression(
            validationContext.ObjectType, _condition);

        var conditionMet = (bool)(conditionFunction.DynamicInvoke(
            validationContext.ObjectInstance) ?? throw new InvalidOperationException());

        if (!conditionMet)
        {
            return new ValidationResult(_errorMessage);
        };

        if (value != null && int.TryParse(value.ToString(), out var parsedValue))
        {
            return parsedValue == 0
                ? new ValidationResult($"Field {validationContext.MemberName} is required")
                : null;
        }

        return new ValidationResult($"Field {validationContext.MemberName} is required");
    }

    private static Delegate CreateExpression(Type objectType, string expression)
    {
        var lambdaExpression =
            DynamicExpressionParser.ParseLambda(
                objectType, typeof(bool), expression);
        var func = lambdaExpression.Compile();
        return func;
    }
}