using FluentValidator.Validators.Interfaces;

namespace FluentValidator.Validators
{
    internal class EnumValidator<TEnum> : ValidatorBase<IEnumValidator<TEnum>, TEnum>, IEnumValidator<TEnum>
        where TEnum : struct, Enum
    {
        public EnumValidator(TEnum? input, bool allowNull = false, string? parameterName = null)
            : base(input ?? GetSafeDefault(), parameterName, allowNull)
        {
            if (!allowNull && input is null || allowNull! && Value.Equals(GetSafeDefault()))
                Throw($"Parameter '{parameterName}' cannot be null or default.");
        }

        public IEnumValidator<TEnum> Defined(string? message = null)
        {
            if (!Enum.IsDefined(Value))
                Throw(message ?? $"Parameter '{ParameterName}' must be a defined enum value.");

            return this;
        }

        public IEnumValidator<TEnum> NotDefined(string? message = null)
        {
            if (Enum.IsDefined(Value))
                Throw(message ?? $"Parameter '{ParameterName}' must not be a defined enum value.");

            return this;
        }

        public IEnumValidator<TEnum> Defined(params TEnum[] values)
        {
            if (!values.Contains(Value))
                Throw($"Parameter '{ParameterName}' must be one of the specified enum values: {string.Join(", ", values)}.");

            return this;
        }

        public IEnumValidator<TEnum> NotDefined(params TEnum[] values)
        {
            if (values.Contains(Value))
                Throw($"Parameter '{ParameterName}' must not be one of the specified enum values: {string.Join(", ", values)}.");

            return this;
        }

        private static TEnum GetSafeDefault()
        {
            var values = Enum.GetValues<TEnum>();
            return values.Length > 0 ? values[0] : default;
        }
    }
}
