namespace Validator.Validators.Interfaces
{
    /// <summary>
    /// Provides validation methods for collections.
    /// </summary>
    public interface ICollectionValidator<TValue> : IValidator<ICollectionValidator<TValue>, IEnumerable<TValue>>
    {
        /// <summary>
        /// Ensures the collection is not empty.
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        ICollectionValidator<TValue> NotEmpty(string? message = null);

        /// <summary>
        /// Ensures the collection contains at least a specified number of elements.
        /// </summary>
        /// <param name="minCount">Minimum number of elements.</param>
        /// <param name="message">Optional custom error message.</param>
        ICollectionValidator<TValue> MinCount(int minCount, string? message = null);

        /// <summary>
        /// Ensures the collection contains at most a specified number of elements.
        /// </summary>
        /// <param name="maxCount">Maximum number of elements.</param>
        /// <param name="message">Optional custom error message.</param>
        ICollectionValidator<TValue> MaxCount(int maxCount, string? message = null);

        /// <summary>
        /// Ensures the collection contains between a minimum and maximum number of elements.
        /// </summary>
        /// <param name="minCount">Minimum number of elements.</param>
        /// <param name="maxCount">Maximum number of elements.</param>
        /// <param name="message">Optional custom error message.</param>
        ICollectionValidator<TValue> CountBetween(int minCount, int maxCount, string? message = null);

        /// <summary>
        /// Ensures the collection contains a specified value.
        /// </summary>
        /// <param name="value">Value to check for.</param>
        /// <param name="message">Optional custom error message.</param>
        ICollectionValidator<TValue> Contains(TValue value, string? message = null);

        /// <summary>
        /// Ensures the collection does not contain a specified value.
        /// </summary>
        /// <param name="value">Value to check for.</param>
        /// <param name="message">Optional custom error message.</param>
        ICollectionValidator<TValue> DoesNotContain(TValue value, string? message = null);

        /// <summary>
        /// Ensures the collection contains only unique elements.
        /// </summary>
        /// <param name="message">Optional custom error message.</param>
        ICollectionValidator<TValue> Unique(string? message = null);
    }
}
