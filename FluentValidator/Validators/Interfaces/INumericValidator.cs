namespace FluentValidator.Validators.Interfaces
{
    /// <summary>
    /// Provides validation methods for numeric values.
    /// </summary>
    /// <typeparam name="TValue">The numeric type to validate.</typeparam>
    public interface INumericValidator<TValue> : IValidator<INumericValidator<TValue>, TValue> where TValue : struct, IComparable<TValue>
    {
        /// <summary>
        /// Ensures the value is greater than or equal to the specified minimum.
        /// </summary>
        /// <param name="minValue">The minimum allowed value.</param>
        /// <param name="message">Optional custom error message.</param>
        INumericValidator<TValue> Min(TValue minValue, string? message = null);

        /// <summary>
        /// Ensures the value is less than or equal to the specified maximum.
        /// </summary>
        /// <param name="maxValue">The maximum allowed value.</param>
        /// <param name="message">Optional custom error message.</param>
        INumericValidator<TValue> Max(TValue maxValue, string? message = null);

        /// <summary>
        /// Ensures the value is within the specified range (inclusive).
        /// </summary>
        /// <param name="minValue">The minimum allowed value.</param>
        /// <param name="maxValue">The maximum allowed value.</param>
        /// <param name="message">Optional custom error message.</param>
        INumericValidator<TValue> MinMax(TValue minValue, TValue maxValue, string? message = null);

        /// <summary>
        /// Ensures the value is positive (> 0).
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        INumericValidator<TValue> Positive(string? message = null);

        /// <summary>
        /// Ensures the value is negative (< 0).
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        INumericValidator<TValue> Negative(string? message = null);

        /// <summary>
        /// Ensures the value is an even number.
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        INumericValidator<TValue> Even(string? message = null);

        /// <summary>
        /// Ensures the value is an odd number.
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        INumericValidator<TValue> Odd(string? message = null);

        /// <summary>
        /// Ensures the value is divisible by the specified divisor.
        /// </summary>
        /// <param name="divisor">The divisor to check.</param>
        /// <param name="message">Optional custom error message.</param>
        INumericValidator<TValue> DivisibleBy(TValue divisor, string? message = null);

        /// <summary>
        /// Ensures the value is not zero.
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        INumericValidator<TValue> NotZero(string? message = null);

        /// <summary>
        /// Ensures the value is equal to the specified value.
        /// </summary>
        /// <param name="value">The required value.</param>
        /// <param name="message">Optional custom error message.</param>
        INumericValidator<TValue> EqualTo(TValue value, string? message = null);

        /// <summary>
        /// Ensures the value is not equal to the specified value.
        /// </summary>
        /// <param name="value">The value to check against.</param>
        /// <param name="message">Optional custom error message.</param>
        INumericValidator<TValue> NotEqualTo(TValue value, string? message = null);

        /// <summary>
        /// Ensures the value is strictly between the specified minimum and maximum (exclusive).
        /// </summary>
        /// <param name="minValue">The minimum bound (exclusive).</param>
        /// <param name="maxValue">The maximum bound (exclusive).</param>
        /// <param name="message">Optional custom error message.</param>
        INumericValidator<TValue> BetweenExclusive(TValue minValue, TValue maxValue, string? message = null);

        /// <summary>
        /// Ensures the value is not present in the specified set of values.
        /// </summary>
        /// <param name="values">The disallowed values.</param>
        INumericValidator<TValue> NotPresentIn(params TValue[] values);

        /// <summary>
        /// Ensures the value is present in the specified set of values.
        /// </summary>
        /// <param name="values">The allowed values.</param>
        INumericValidator<TValue> PresentIn(params TValue[] values);
    }
}
