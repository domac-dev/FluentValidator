using Library.Validator.Validators;

namespace Library.Validator { 

    public interface IValidator {

    }

    public class Validator : IValidator
    {
        public static IValidator Numeric { get; } = new NumericValidator();
        private Validator() { }
    }
}
