using System.Runtime.CompilerServices;
using Validator.Exceptions;

namespace Validator
{
    public abstract class FluentValidator<TFluentValidator, TValue> : IValidator<TFluentValidator, TValue>
    {
        public TValue? Value { get; private set; }
        protected string ParameterName {  get; private set; }
        protected FluentValidator(TValue? input, [CallerArgumentExpression(nameof(input))] string? paramName = null, bool allowNull = false) {
            Value = input;
            ParameterName = string.IsNullOrEmpty(paramName) ? string.Empty : paramName;

            if (!allowNull)          
                NotNull(paramName!);

            else if (input is null)
                return;
        }

        protected FluentValidator<TFluentValidator, TValue> NotNull(string? message = null)
        {
            if (Value is null)
                ValidatorException.Throw(message ?? $"Parameter '{ParameterName}' cannot be null.");

            return this;
        }
    }
}
