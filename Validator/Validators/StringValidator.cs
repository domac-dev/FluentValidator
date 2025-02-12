using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Validator.Exceptions;
using Validator.Validators.Interfaces;

namespace Validator.Validators
{
    internal class StringValidator(string? input, bool allowNull = false, [CallerArgumentExpression(nameof(input))] string? parameterName = null)
        : ValidatorBase<IStringValidator, string>(input, parameterName, allowNull), IStringValidator
    {
        public IStringValidator StartsWith(string value, string? message = null)
        {
            if (!Value!.StartsWith(value))
                Throw(message ?? $"Parameter '{ParameterName}' must start with \"{value}\".");

            return this;
        }

        public IStringValidator EndsWith(string value, string? message = null)
        {
            if (!Value!.EndsWith(value))
                Throw(message ?? $"Parameter '{ParameterName}' must end with \"{value}\".");

            return this;
        }

        public IStringValidator IsNumeric(string? message = null)
        {
            if (!Value!.All(char.IsDigit))
                Throw(message ?? $"Parameter '{ParameterName}' must contain only numeric characters.");

            return this;
        }

        public IStringValidator IsAlpha(string? message = null)
        {
            if (!Value!.All(char.IsLetter))
                Throw(message ?? $"Parameter '{ParameterName}' must contain only letters.");

            return this;
        }

        public IStringValidator IsAlphaNumeric(string? message = null)
        {
            if (!Value!.All(char.IsLetterOrDigit))
                Throw(message ?? $"Parameter '{ParameterName}' must contain only letters and numbers.");

            return this;
        }

        public IStringValidator IsGuid(string? message = null)
        {
            if (!Guid.TryParse(Value, out _))
                Throw(message ?? $"Parameter '{ParameterName}' must be a valid GUID.");

            return this;
        }

        public IStringValidator IsBase64(string? message = null)
        {
            try
            {
                Convert.FromBase64String(Value!);
            }
            catch
            {
                Throw(message ?? $"Parameter '{ParameterName}' must be a valid Base64 string.");
            }

            return this;
        }

        public IStringValidator HasOnlyDigits(string? message = null)
        {
            if (!Value!.All(char.IsDigit))
                Throw(message ?? $"Parameter '{ParameterName}' must contain only digits (0-9).");

            return this;
        }

        public IStringValidator HasOnlyLetters(string? message = null)
        {
            if (!Value!.All(char.IsLetter))
                Throw(message ?? $"Parameter '{ParameterName}' must contain only letters (A-Z, a-z).");

            return this;
        }

        public IStringValidator UpperCase(string? message = null)
        {
            if (Value!.Any(char.IsLower))
                Throw(message ?? $"Parameter '{ParameterName}' must be entirely uppercase.");

            return this;
        }

        public IStringValidator LowerCase(string? message = null)
        {
            if (Value!.Any(char.IsUpper))
                Throw(message ?? $"Parameter '{ParameterName}' must be entirely lowercase.");

            return this;
        }

        public IStringValidator MatchesPattern(Regex regex, string? message = null)
        {
            if (!regex.IsMatch(Value!))
                Throw(message ?? "Invalid format.");

            return this;
        }

        public IStringValidator MatchesPattern(string regex, string? message = null)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(Value!, regex))
                Throw(message ?? "Invalid format.");

            return this;
        }

        public IStringValidator MinMaxLength(int minLength, int maxLength, string? message = null)
        {
            if (Value!.Length < minLength || Value!.Length > maxLength)
                Throw(message ?? $"Parameter '{ParameterName}' must be between {minLength} and {maxLength} characters long.");

            return this;
        }

        public IStringValidator NullOrWhiteSpace(string? message = null)
        {
            if (string.IsNullOrWhiteSpace(Value))
                Throw(message ?? $"Parameter '{ParameterName}' cannot be null or whitespace.");

            return this;
        }

        public IStringValidator MinLength(int minLength, string? message = null)
        {
            if (Value!.Length < minLength)
                Throw(message ?? $"Parameter '{ParameterName}' must be at least {minLength} characters long.");

            return this;
        }

        public IStringValidator MaxLength(int maxLength, string? message = null)
        {
            if (Value!.Length > maxLength)
                Throw(message ?? $"Parameter '{ParameterName}' must be at most {maxLength} characters long.");

            return this;
        }

        public IStringValidator IPAddress(string? message = null)
        {
            if (!System.Net.IPAddress.TryParse(Value, out _))
                Throw(message ?? "Invalid IP address format.");

            return this;
        }

        public IStringValidator EmailAddress(string? message = null)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(Value!, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                Throw(message ?? "Invalid email address format.");

            return this;
        }

        public IStringValidator Contains(char value, string? message = null)
        {
            if (!Value!.Contains(value))
                Throw(message ?? $"Parameter '{ParameterName}' must contain '{value}'.");

            return this;
        }

        public IStringValidator Contains(string value, string? message = null)
        {
            if (!Value!.Contains(value))
                Throw(message ?? $"Parameter '{ParameterName}' must contain \"{value}\".");

            return this;
        }

        public IStringValidator Contains(IEnumerable<char> values, string? message = null)
        {
            if (!values.Any(Value!.Contains))
                Throw(message ?? $"Parameter '{ParameterName}' must contain at least one of the specified characters.");

            return this;
        }

        public IStringValidator Contains(IEnumerable<string> values, string? message = null)
        {
            if (!values.Any(Value!.Contains))
                Throw(message ?? $"Parameter '{ParameterName}' must contain at least one of the specified strings.");

            return this;
        }

        public IStringValidator DoesNotContain(char value, string? message = null)
        {
            if (Value!.Contains(value))
                Throw(message ?? $"Parameter '{ParameterName}' must not contain '{value}'.");

            return this;
        }

        public IStringValidator DoesNotContain(string value, string? message = null)
        {
            if (Value!.Contains(value))
                Throw(message ?? $"Parameter '{ParameterName}' must not contain \"{value}\".");

            return this;
        }

        public IStringValidator DoesNotContain(IEnumerable<char> values, string? message = null)
        {
            if (values.Any(Value!.Contains))
                Throw(message ?? $"Parameter '{ParameterName}' must not contain any of the specified characters.");

            return this;
        }

        public IStringValidator DoesNotContain(IEnumerable<string> values, string? message = null)
        {
            if (values.Any(Value!.Contains))
                Throw(message ?? $"Parameter '{ParameterName}' must not contain any of the specified strings.");

            return this;
        }
    }
}
