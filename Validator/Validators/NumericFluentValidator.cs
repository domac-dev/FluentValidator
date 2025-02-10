using System;
using System.Runtime.CompilerServices;
using Validator.Exceptions;

namespace Validator.Validators
{
    public interface INumericValidator<TValue> : IValidator<INumericValidator<TValue>, TValue>
        where TValue : struct, IComparable<TValue>
    {
        INumericValidator<TValue> Min(TValue minValue, string? message = null);
        INumericValidator<TValue> Max(TValue maxValue, string? message = null);
        INumericValidator<TValue> MinMax(TValue minValue, TValue maxValue, string? message = null);
        INumericValidator<TValue> Positive(string? message = null);
    }

    internal class NumericFluentValidator<TValue>: FluentValidator<INumericValidator<TValue>, TValue>, INumericValidator<TValue>
            where TValue : struct, IComparable<TValue>
    {

        private static readonly HashSet<Type> SUPPORTED_TYPES =
        [
            typeof(byte), typeof(sbyte),
            typeof(short), typeof(ushort),
            typeof(int), typeof(uint),
            typeof(long), typeof(ulong),
            typeof(float), typeof(double),
            typeof(decimal)
        ];

        public NumericFluentValidator(TValue input, bool allowNull = false, string? parameterName = null)
            :base(input, parameterName, allowNull)
        {
            if (!SUPPORTED_TYPES.Contains(typeof(TValue)))
                throw new InvalidOperationException($"Type '{typeof(TValue)}' is not a valid numeric type.");
        }

        public INumericValidator<TValue> Min(TValue minValue, string? message = null)
        {
            if (Value.CompareTo(minValue) < 0)
                ValidatorException.Throw(message ?? $"Parameter '{ParameterName}' must be at least {minValue}.");

            return this;
        }

        public INumericValidator<TValue> Max(TValue maxValue, string? message = null)
        {
            if (Value.CompareTo(maxValue) > 0)
                ValidatorException.Throw(message ?? $"Parameter '{ParameterName}' must be at most {maxValue}.");

            return this;
        }

        public INumericValidator<TValue> MinMax(TValue minValue, TValue maxValue, string? message = null)
        {
            if (Value.CompareTo(minValue) < 0 || Value.CompareTo(maxValue) > 0)
                ValidatorException.Throw(message ?? $"Parameter '{ParameterName}' must be between {minValue} and {maxValue}.");

            return this;
        }

        public INumericValidator<TValue> Positive(string? message = null)
        {
            if (Value.CompareTo(default) <= 0)
                ValidatorException.Throw(message ?? $"Parameter '{ParameterName}' must be positive.");

            return this;
        }
    }
}
