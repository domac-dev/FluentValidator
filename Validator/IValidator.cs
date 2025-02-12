namespace Validator
{
    public interface IValidator<TFluentValidator, TValue>
    {
        public TValue? Value { get; }
        public IValidator<TFluentValidator, TValue> NotNull(string? message = null);
    }
}
