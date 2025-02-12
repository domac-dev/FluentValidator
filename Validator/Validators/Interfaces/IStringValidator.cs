using System.Text.RegularExpressions;

namespace Validator.Validators.Interfaces
{
    /// <summary>
    /// Provides validation methods for string values.
    /// </summary>
    public interface IStringValidator : IValidator<IStringValidator, string>
    {
        /// <summary>
        /// Ensures the string is a valid IP address.
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        IStringValidator IPAddress(string? message = null);

        /// <summary>
        /// Ensures the string is a valid email address.
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        IStringValidator EmailAddress(string? message = null);

        /// <summary>
        /// Ensures the string is null, empty, or consists only of whitespace characters.
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        IStringValidator NullOrWhiteSpace(string? message = null);

        /// <summary>
        /// Ensures the string has at least the specified minimum length.
        /// </summary>
        /// <param name="minLength">The minimum required length.</param>
        /// <param name="message">Optional custom error message.</param>
        IStringValidator MinLength(int minLength, string? message = null);

        /// <summary>
        /// Ensures the string does not exceed the specified maximum length.
        /// </summary>
        /// <param name="maxLength">The maximum allowed length.</param>
        /// <param name="message">Optional custom error message.</param>
        IStringValidator MaxLength(int maxLength, string? message = null);

        /// <summary>
        /// Ensures the string length is within the specified range.
        /// </summary>
        /// <param name="minLength">The minimum required length.</param>
        /// <param name="maxLength">The maximum allowed length.</param>
        /// <param name="message">Optional custom error message.</param>
        IStringValidator MinMaxLength(int minLength, int maxLength, string? message = null);

        /// <summary>
        /// Ensures the string matches the specified regular expression pattern.
        /// </summary>
        /// <param name="regex">The regex pattern as a string.</param>
        /// <param name="message">Optional custom error message.</param>
        IStringValidator MatchesPattern(string regex, string? message = null);

        /// <summary>
        /// Ensures the string matches the specified compiled regular expression.
        /// </summary>
        /// <param name="regex">The compiled Regex pattern.</param>
        /// <param name="message">Optional custom error message.</param>
        IStringValidator MatchesPattern(Regex regex, string? message = null);

        /// <summary>
        /// Ensures the string contains the specified character.
        /// </summary>
        /// <param name="value">The character to check for.</param>
        /// <param name="message">Optional custom error message.</param>
        IStringValidator Contains(char value, string? message = null);

        /// <summary>
        /// Ensures the string contains the specified substring.
        /// </summary>
        /// <param name="value">The substring to check for.</param>
        /// <param name="message">Optional custom error message.</param>
        IStringValidator Contains(string value, string? message = null);

        /// <summary>
        /// Ensures the string contains at least one of the specified characters.
        /// </summary>
        /// <param name="values">The characters to check for.</param>
        /// <param name="message">Optional custom error message.</param>
        IStringValidator Contains(IEnumerable<char> values, string? message = null);

        /// <summary>
        /// Ensures the string contains at least one of the specified substrings.
        /// </summary>
        /// <param name="values">The substrings to check for.</param>
        /// <param name="message">Optional custom error message.</param>
        IStringValidator Contains(IEnumerable<string> values, string? message = null);

        /// <summary>
        /// Ensures the string does not contain the specified character.
        /// </summary>
        IStringValidator DoesNotContain(char value, string? message = null);

        /// <summary>
        /// Ensures the string does not contain the specified substring.
        /// </summary>
        IStringValidator DoesNotContain(string value, string? message = null);

        /// <summary>
        /// Ensures the string does not contain any of the specified characters.
        /// </summary>
        IStringValidator DoesNotContain(IEnumerable<char> values, string? message = null);

        /// <summary>
        /// Ensures the string does not contain any of the specified substrings.
        /// </summary>
        IStringValidator DoesNotContain(IEnumerable<string> values, string? message = null);

        /// <summary>
        /// Ensures the string consists only of uppercase characters.
        /// </summary>
        IStringValidator UpperCase(string? message = null);

        /// <summary>
        /// Ensures the string consists only of lowercase characters.
        /// </summary>
        IStringValidator LowerCase(string? message = null);

        /// <summary>
        /// Ensures the string starts with the specified value.
        /// </summary>
        IStringValidator StartsWith(string value, string? message = null);

        /// <summary>
        /// Ensures the string ends with the specified value.
        /// </summary>
        IStringValidator EndsWith(string value, string? message = null);

        /// <summary>
        /// Ensures the string contains only numeric characters.
        /// </summary>
        IStringValidator IsNumeric(string? message = null);

        /// <summary>
        /// Ensures the string contains only alphabetic characters.
        /// </summary>
        IStringValidator IsAlpha(string? message = null);

        /// <summary>
        /// Ensures the string contains only alphanumeric characters.
        /// </summary>
        IStringValidator IsAlphaNumeric(string? message = null);

        /// <summary>
        /// Ensures the string is a valid GUID.
        /// </summary>
        IStringValidator IsGuid(string? message = null);

        /// <summary>
        /// Ensures the string is a valid Base64-encoded value.
        /// </summary>
        IStringValidator IsBase64(string? message = null);

        /// <summary>
        /// Ensures the string contains only digit characters (0-9).
        /// </summary>
        IStringValidator HasOnlyDigits(string? message = null);

        /// <summary>
        /// Ensures the string contains only letter characters (A-Z, a-z).
        /// </summary>
        IStringValidator HasOnlyLetters(string? message = null);
    }
}
