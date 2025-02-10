namespace Validator
{
    public interface IValidator<TFluentValidator, TValue>
    {
        public TValue? Value { get; }
    }
}
