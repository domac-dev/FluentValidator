namespace Validator
{
    /// <summary>
    /// Defines a generic interface for a validator that validates values of type <typeparamref name="TValue"/>
    /// and provides a fluent API for validation methods.
    /// </summary>
    /// <typeparam name="TFluentValidator">The type of the fluent validator, typically the implementing class.</typeparam>
    /// <typeparam name="TValue">The type of the value being validated.</typeparam>
    public interface IValidator<TFluentValidator, TValue>
    {
        /// <summary>
        /// Gets the value that is being validated.
        /// </summary>
        public TValue? Value { get; }

        /// <summary>
        /// Validates that the value is not null.
        /// </summary>
        /// <param name="message">An optional custom error message.</param>
        /// <returns>The current validator instance for method chaining.</returns>
        public IValidator<TFluentValidator, TValue> NotNull(string? message = null);
    }
}
