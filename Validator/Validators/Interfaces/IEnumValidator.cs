namespace FluentValidator.Validators.Interfaces
{
    /// <summary>
    /// Provides validation methods for enumerations.
    /// </summary>
    /// <typeparam name="TEnum">The enum type to validate.</typeparam>
    public interface IEnumValidator<TEnum> : IValidator<IEnumValidator<TEnum>, TEnum> where TEnum : struct, Enum
    {
        /// <summary>
        /// Ensures the enum value is one of the specified valid values.
        /// </summary>
        /// <param name="values">The allowed enum values.</param>
        IEnumValidator<TEnum> Defined(params TEnum[] values);

        /// <summary>
        /// Ensures the enum value is defined within the enum type.
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        IEnumValidator<TEnum> Defined(string? message = null);

        /// <summary>
        /// Ensures the enum value is not defined within the enum type.
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        IEnumValidator<TEnum> NotDefined(string? message = null);

        /// <summary>
        /// Ensures the enum value is not one of the specified values.
        /// </summary>
        /// <param name="values">The disallowed enum values.</param>
        IEnumValidator<TEnum> NotDefined(params TEnum[] values);
    }
}
