using Validator.Validators.Interfaces;

namespace Validator.Validators
{
    internal class DateTimeValidator(DateTime input, bool allowNull = false, string? parameterName = null)
        : ValidatorBase<IDateTimeValidator, DateTime>(input, parameterName, allowNull), IDateTimeValidator
    {
        public IDateTimeValidator NotDefault(string? message = null)
        {
            if (Value == default)
                Throw(message ?? $"Parameter '{ParameterName}' must not be the default DateTime value.");

            return this;
        }

        public IDateTimeValidator InPast(string? message = null)
        {
            if (Value >= DateTime.Now)
                Throw(message ?? $"Parameter '{ParameterName}' must be in the past.");

            return this;
        }

        public IDateTimeValidator InFuture(string? message = null)
        {
            if (Value <= DateTime.Now)
                Throw(message ?? $"Parameter '{ParameterName}' must be in the future.");

            return this;
        }

        public IDateTimeValidator Min(DateTime minDate, string? message = null)
        {
            if (Value < minDate)
                Throw(message ?? $"Parameter '{ParameterName}' must be on or after {minDate}.");

            return this;
        }

        public IDateTimeValidator Max(DateTime maxDate, string? message = null)
        {
            if (Value > maxDate)
                Throw(message ?? $"Parameter '{ParameterName}' must be on or before {maxDate}.");

            return this;
        }

        public IDateTimeValidator Between(DateTime minDate, DateTime maxDate, string? message = null)
        {
            if (Value < minDate || Value > maxDate)
                Throw(message ?? $"Parameter '{ParameterName}' must be between {minDate} and {maxDate}.");

            return this;
        }

        public IDateTimeValidator IsWeekend(string? message = null)
        {
            if (Value.DayOfWeek != DayOfWeek.Saturday && Value.DayOfWeek != DayOfWeek.Sunday)
                Throw(message ?? $"Parameter '{ParameterName}' must be a weekend (Saturday or Sunday).");

            return this;
        }

        public IDateTimeValidator IsWeekday(string? message = null)
        {
            if (Value.DayOfWeek == DayOfWeek.Saturday || Value.DayOfWeek == DayOfWeek.Sunday)
                Throw(message ?? $"Parameter '{ParameterName}' must be a weekday (Monday to Friday).");

            return this;
        }
    }
}
