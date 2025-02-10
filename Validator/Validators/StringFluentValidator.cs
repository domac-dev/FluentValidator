using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Validator.Exceptions;

namespace Validator.Validators
{

    public interface IStringValidator : IValidator<IStringValidator, string>
    {
        IStringValidator IPAddress(string? message = null);
        IStringValidator EmailAddress(string? message = null);
        IStringValidator NullOrWhiteSpace(string? message = null);
        IStringValidator MinLength(int minLength, string? message = null);
        IStringValidator MaxLength(int maxLength, string? message = null);
        IStringValidator MinMaxLength(int minLength, int maxLength, string? message = null);
        IStringValidator Regex(string regex, string? message = null);
        IStringValidator Regex(Regex regex, string? message = null);
    }

    internal class StringFluentValidator(string? input, bool allowNull = false, [CallerArgumentExpression(nameof(input))] string? parameterName = null)
        : FluentValidator<IStringValidator, string>(input, parameterName, allowNull), IStringValidator
    {
        public IStringValidator Regex(Regex regex, string? message = null)
        {
            if (!regex.IsMatch(Value!))
                ValidatorException.Throw(message ?? "Invalid format.");

            return this;
        }

        public IStringValidator Regex(string regex, string? message = null)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(Value!, regex))
                ValidatorException.Throw(message ?? "Invalid format.");

            return this;
        }

        public IStringValidator MinMaxLength(int minLength, int maxLength, string? message = null)
        {
            if (Value!.Length < minLength || Value!.Length > maxLength)
                ValidatorException.Throw(message ?? $"Parameter '{ParameterName}' must be between {minLength} and {maxLength} characters long.");

            return this;
        }

        public IStringValidator NullOrWhiteSpace(string? message = null)
        {
            if (string.IsNullOrWhiteSpace(Value))
                ValidatorException.Throw(message ?? $"Parameter '{ParameterName}' cannot be null or whitespace.");

            return this;
        }

        public IStringValidator MinLength(int minLength, string? message = null)
        {
            if (Value!.Length < minLength)
                ValidatorException.Throw(message ?? $"Parameter '{ParameterName}' must be at least {minLength} characters long.");

            return this;
        }

        public IStringValidator MaxLength(int maxLength, string? message = null)
        {
            if (Value!.Length > maxLength)
                ValidatorException.Throw(message ?? $"Parameter '{ParameterName}' must be at most {maxLength} characters long.");

            return this;
        }

        public IStringValidator Length(int minLength, int maxLength, string? message = null)
        {
            if (Value!.Length < minLength || Value.Length > maxLength)
                ValidatorException.Throw(message ?? $"Parameter '{ParameterName}' must be between {minLength} and {maxLength} characters long.");

            return this;
        }

        public IStringValidator IPAddress(string? message = null)
        {
            if (!System.Net.IPAddress.TryParse(Value, out _))
                ValidatorException.Throw(message ?? "Invalid IP address format.");

            return this;
        }

        public IStringValidator EmailAddress(string? message = null)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(Value!, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                ValidatorException.Throw(message ?? "Invalid email address format.");

            return this;
        }
    }
}
