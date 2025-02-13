namespace FluentValidator.Exceptions
{
    public class ValidatorException : Exception
    {
        public ValidationSeverity ValidationSeverity { get; } = ValidationSeverity.Error;
        public ValidatorException(string message) : base(message) { }
        public ValidatorException(string message, ValidationSeverity validationSeverity = ValidationSeverity.Error) : base(message)
        {
            ValidationSeverity = validationSeverity;
        }

        public static void Throw(string message, ValidationSeverity validationSeverity = ValidationSeverity.Error)
            => throw new ValidatorException(message, validationSeverity);
    }
}
