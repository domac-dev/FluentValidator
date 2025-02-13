namespace FluentValidator.Validators.Interfaces
{
    /// <summary>
    /// Provides validation methods for DateTime values.
    /// </summary>
    public interface IDateTimeValidator : IValidator<IDateTimeValidator, DateTime>
    {
        /// <summary>
        /// Ensures the DateTime value is not the default value (0001-01-01 00:00:00).
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        IDateTimeValidator NotDefault(string? message = null);

        /// <summary>
        /// Ensures the DateTime value is in the past.
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        IDateTimeValidator InPast(string? message = null);

        /// <summary>
        /// Ensures the DateTime value is in the future.
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        IDateTimeValidator InFuture(string? message = null);

        /// <summary>
        /// Ensures the DateTime value is on or after the specified minimum date.
        /// </summary>
        /// <param name="minDate">The minimum allowed DateTime value.</param>
        /// <param name="message">Optional custom error message.</param>
        IDateTimeValidator Min(DateTime minDate, string? message = null);

        /// <summary>
        /// Ensures the DateTime value is on or before the specified maximum date.
        /// </summary>
        /// <param name="maxDate">The maximum allowed DateTime value.</param>
        /// <param name="message">Optional custom error message.</param>
        IDateTimeValidator Max(DateTime maxDate, string? message = null);

        /// <summary>
        /// Ensures the DateTime value falls within a specified range.
        /// </summary>
        /// <param name="minDate">The minimum allowed DateTime value.</param>
        /// <param name="maxDate">The maximum allowed DateTime value.</param>
        /// <param name="message">Optional custom error message.</param>
        IDateTimeValidator Between(DateTime minDate, DateTime maxDate, string? message = null);

        /// <summary>
        /// Ensures the DateTime value falls on a weekend (Saturday or Sunday).
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        IDateTimeValidator IsWeekend(string? message = null);

        /// <summary>
        /// Ensures the DateTime value falls on a weekday (Monday to Friday).
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        IDateTimeValidator IsWeekday(string? message = null);
    }
}
