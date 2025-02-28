using FluentValidator.Validators.Interfaces;

namespace FluentValidator.Validators
{
    internal class CollectionValidator<T>(IEnumerable<T> input, bool allowNull = false, string? parameterName = null)
        : ValidatorBase<ICollectionValidator<T>, IEnumerable<T>>(input, parameterName, allowNull), ICollectionValidator<T>
    {
        public ICollectionValidator<T> NotEmpty(string? message = null)
        {
            if (!Input.Any())
                Throw(message ?? $"Collection '{ParameterName}' must not be empty.");

            return this;
        }

        public ICollectionValidator<T> MinCount(int minCount, string? message = null)
        {
            if (Input.Count() < minCount)
                Throw(message ?? $"Collection '{ParameterName}' must contain at least {minCount} elements.");

            return this;
        }

        public ICollectionValidator<T> MaxCount(int maxCount, string? message = null)
        {
            if (Input.Count() > maxCount)
                Throw(message ?? $"Collection '{ParameterName}' must contain at most {maxCount} elements.");

            return this;
        }

        public ICollectionValidator<T> CountBetween(int minCount, int maxCount, string? message = null)
        {
            int count = Input.Count();
            if (count < minCount || count > maxCount)
                Throw(message ?? $"Collection '{ParameterName}' must contain between {minCount} and {maxCount} elements.");

            return this;
        }

        public ICollectionValidator<T> Contains(T value, string? message = null)
        {
            if (!Input.Contains(value))
                Throw(message ?? $"Collection '{ParameterName}' must contain the specified value.");

            return this;
        }

        public ICollectionValidator<T> DoesNotContain(T value, string? message = null)
        {
            if (Input.Contains(value))
                Throw(message ?? $"Collection '{ParameterName}' must not contain the specified value.");

            return this;
        }

        public ICollectionValidator<T> Unique(string? message = null)
        {
            if (Input.Distinct().Count() != Input.Count())
                Throw(message ?? $"Collection '{ParameterName}' must contain only unique elements.");

            return this;
        }
    }
}
