using FluentValidator.Exceptions;

namespace FluentValidator
{
    public abstract class ValidatorBase<TFluentValidator, TValue> : IValidator<TFluentValidator, TValue>
    {
        public TValue Input { get; private set; } = default!;
        protected string ParameterName { get; private set; } = string.Empty;
        protected ValidatorBase(TValue? input, string? paramName = null, bool allowNull = false)
        {
            if (!allowNull)
                NotNull(input);

            else if (input is null)
                return;

            Input = input!;
            ParameterName = paramName ?? string.Empty;
        }

        protected void Throw(string message) => ValidatorException.Throw(message);
        private TValue NotNull(TValue? value) => value ?? throw new ValidatorException($"Parameter '{ParameterName}' cannot be null.");
    }
}
