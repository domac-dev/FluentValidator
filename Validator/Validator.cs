using System.Runtime.CompilerServices;
using Validator.Validators;
using Validator.Validators.Interfaces;

namespace Validator
{
    public class Validator
    {
        public static IStringValidator String(string? input, bool allowNull = false,
            [CallerArgumentExpression(nameof(input))] string? parameterName = null)
        {
            return new StringValidator(input, allowNull, parameterName);
        }

        public static INumericValidator<TValue> Numeric<TValue>(TValue input, bool allowNull = false,
            [CallerArgumentExpression(nameof(input))] string? parameterName = null) where TValue : struct, IComparable<TValue>
        {
            return new NumericValidator<TValue>(input, allowNull, parameterName);
        }

        public static ICollectionValidator<TValue> Collection<TValue>(IEnumerable<TValue> input, bool allowNull = false,
            [CallerArgumentExpression(nameof(input))] string? parameterName = null) where TValue : struct, IComparable<TValue>
        {
            return new CollectionValidator<TValue>(input, allowNull, parameterName);
        }

        public static IEnumValidator<TEnum> Enum<TEnum>(TEnum? input, bool allowNull = false,
            [CallerArgumentExpression(nameof(input))] string? parameterName = null) where TEnum : struct, Enum
        {
            return new EnumValidator<TEnum>(input, allowNull, parameterName);
        }

        public static IDateTimeValidator Date(DateTime input, bool allowNull = false,
            [CallerArgumentExpression(nameof(input))] string? parameterName = null)
        {
            return new DateTimeValidator(input, allowNull, parameterName);
        }
    }
}
