using Validator.Exceptions;

namespace Validator
{
    public abstract class ValidatorBase<TFluentValidator, TValue> : IValidator<TFluentValidator, TValue>
    {
        public TValue? Value { get; private set; }
        protected string ParameterName { get; private set; }
        protected ValidatorBase(TValue? input, string? paramName = null, bool allowNull = false)
        {
            Value = input;
            ParameterName = paramName ?? string.Empty;

            if (!allowNull)
                NotNull(paramName!);

            else if (input is null)
                return;
        }

        public IValidator<TFluentValidator, TValue> NotNull(string? message = null)
        {
            if (Value is null)
                Throw(message ?? $"Parameter '{ParameterName}' cannot be null.");

            return this;
        }

        protected void Throw(string message) => ValidatorException.Throw(message);
    }
}
