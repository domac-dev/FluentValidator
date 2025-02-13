using FluentValidator.Validators.Interfaces;

namespace FluentValidator.Validators
{
    internal class NumericValidator<TValue> : ValidatorBase<INumericValidator<TValue>, TValue>, INumericValidator<TValue>
        where TValue : struct, IComparable<TValue>
    {
        public NumericValidator(TValue input, bool allowNull = false, string? parameterName = null)
            : base(input, parameterName, allowNull)
        {
            if (!SUPPORTED_TYPES.Contains(typeof(TValue)))
                Throw($"Type '{typeof(TValue)}' is not a valid numeric type.");
        }

        public INumericValidator<TValue> PresentIn(params TValue[] values)
        {
            if (!values.Contains(Value))
                Throw($"Parameter '{ParameterName}' must be one of the specified values: {string.Join(", ", values)}.");

            return this;
        }

        public INumericValidator<TValue> NotPresentIn(params TValue[] values)
        {
            if (values.Contains(Value))
                Throw($"Parameter '{ParameterName}' must not be one of the specified values: {string.Join(", ", values)}.");

            return this;
        }

        public INumericValidator<TValue> Min(TValue minValue, string? message = null)
        {
            if (Value.CompareTo(minValue) < 0)
                Throw(message ?? $"Parameter '{ParameterName}' must be at least {minValue}.");

            return this;
        }

        public INumericValidator<TValue> Max(TValue maxValue, string? message = null)
        {
            if (Value.CompareTo(maxValue) > 0)
                Throw(message ?? $"Parameter '{ParameterName}' must be at most {maxValue}.");

            return this;
        }

        public INumericValidator<TValue> MinMax(TValue minValue, TValue maxValue, string? message = null)
        {
            if (Value.CompareTo(minValue) < 0 || Value.CompareTo(maxValue) > 0)
                Throw(message ?? $"Parameter '{ParameterName}' must be between {minValue} and {maxValue}.");

            return this;
        }

        public INumericValidator<TValue> Positive(string? message = null)
        {
            if (Value.CompareTo(default) <= 0)
                Throw(message ?? $"Parameter '{ParameterName}' must be positive.");

            return this;
        }

        public INumericValidator<TValue> Negative(string? message = null)
        {
            if (Value.CompareTo(default) >= 0)
                Throw(message ?? $"Parameter '{ParameterName}' must be negative.");

            return this;
        }

        public INumericValidator<TValue> Even(string? message = null)
        {
            dynamic val = Value;
            if (val % 2 != 0)
                Throw(message ?? $"Parameter '{ParameterName}' must be an even number.");

            return this;
        }

        public INumericValidator<TValue> Odd(string? message = null)
        {
            dynamic val = Value;
            if (val % 2 == 0)
                Throw(message ?? $"Parameter '{ParameterName}' must be an odd number.");

            return this;
        }

        public INumericValidator<TValue> DivisibleBy(TValue divisor, string? message = null)
        {
            dynamic val = Value;
            dynamic div = divisor;
            if (div == 0 || val % div != 0)
                Throw(message ?? $"Parameter '{ParameterName}' must be divisible by {divisor}.");

            return this;
        }

        public INumericValidator<TValue> NotZero(string? message = null)
        {
            if (Value.CompareTo(default) == 0)
                Throw(message ?? $"Parameter '{ParameterName}' must not be zero.");

            return this;
        }

        public INumericValidator<TValue> EqualTo(TValue value, string? message = null)
        {
            if (Value.CompareTo(value) != 0)
                Throw(message ?? $"Parameter '{ParameterName}' must be equal to {value}.");

            return this;
        }

        public INumericValidator<TValue> NotEqualTo(TValue value, string? message = null)
        {
            if (Value.CompareTo(value) == 0)
                Throw(message ?? $"Parameter '{ParameterName}' must not be equal to {value}.");

            return this;
        }

        public INumericValidator<TValue> BetweenExclusive(TValue minValue, TValue maxValue, string? message = null)
        {
            if (Value.CompareTo(minValue) <= 0 || Value.CompareTo(maxValue) >= 0)
                Throw(message ?? $"Parameter '{ParameterName}' must be strictly between {minValue} and {maxValue}.");

            return this;
        }

        private static readonly HashSet<Type> SUPPORTED_TYPES =
        [
            typeof(byte), typeof(sbyte),
            typeof(short), typeof(ushort),
            typeof(int), typeof(uint),
            typeof(long), typeof(ulong),
            typeof(float), typeof(double),
            typeof(decimal)
        ];
    }
}
