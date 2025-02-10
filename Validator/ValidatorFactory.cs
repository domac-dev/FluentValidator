using System.Runtime.CompilerServices;
using Validator.Validators;

namespace Validator
{
    public class Validator
    {
        public static IStringValidator String(string? input, bool allowNull = false, [CallerArgumentExpression(nameof(input))] string? parameterName = null)
        {
            return new StringFluentValidator(input, allowNull, parameterName);
        }

        public static INumericValidator<TValue> Numeric<TValue>(TValue input, bool allowNull = false, [CallerArgumentExpression(nameof(input))] string? parameterName = null)
            where TValue : struct, IComparable<TValue>
        {
            return new NumericFluentValidator<TValue>(input, allowNull, parameterName);
        }
    }
}
