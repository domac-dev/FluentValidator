using FluentValidator.Validators.Interfaces;

namespace FluentValidator.Validators
{
    internal class DateTimeValidator(DateTime? input, bool allowNull = false, string? parameterName = null)
        : ValidatorBase<IDateTimeValidator, DateTime?>(input, parameterName, allowNull), IDateTimeValidator
    {
        public IDateTimeValidator NotDefault(string? message = null)
        {
            if (Input!.Value == default)
                Throw(message ?? $"Parameter '{ParameterName}' must not be the default DateTime value.");

            return this;
        }

        public IDateTimeValidator InPast(string? message = null)
        {
            if (Input!.Value >= DateTime.Now)
                Throw(message ?? $"Parameter '{ParameterName}' must be in the past.");

            return this;
        }

        public IDateTimeValidator InFuture(string? message = null)
        {
            if (Input!.Value <= DateTime.Now)
                Throw(message ?? $"Parameter '{ParameterName}' must be in the future.");

            return this;
        }

        public IDateTimeValidator Min(DateTime minDate, string? message = null)
        {
            if (Input!.Value < minDate)
                Throw(message ?? $"Parameter '{ParameterName}' must be on or after {minDate}.");

            return this;
        }

        public IDateTimeValidator Max(DateTime maxDate, string? message = null)
        {
            if (Input!.Value > maxDate)
                Throw(message ?? $"Parameter '{ParameterName}' must be on or before {maxDate}.");

            return this;
        }

        public IDateTimeValidator Between(DateTime minDate, DateTime maxDate, string? message = null)
        {
            if (Input!.Value < minDate || Input!.Value > maxDate)
                Throw(message ?? $"Parameter '{ParameterName}' must be between {minDate} and {maxDate}.");

            return this;
        }

        public IDateTimeValidator IsWeekend(string? message = null)
        {
            if (Input!.Value.DayOfWeek != DayOfWeek.Saturday && Input!.Value.DayOfWeek != DayOfWeek.Sunday)
                Throw(message ?? $"Parameter '{ParameterName}' must be a weekend (Saturday or Sunday).");

            return this;
        }

        public IDateTimeValidator IsWeekday(string? message = null)
        {
            if (Input!.Value.DayOfWeek == DayOfWeek.Saturday || Input!.Value.DayOfWeek == DayOfWeek.Sunday)
                Throw(message ?? $"Parameter '{ParameterName}' must be a weekday (Monday to Friday).");

            return this;
        }
    }
}
