using FluentValidator;
using FluentValidator.Exceptions;

namespace ValidatorTests
{
    public class NumericValidatorTests
    {
        [Fact]
        public void Min_ValidValue_ShouldPass()
        {
            var validator = Validator.Numeric(10).Min(5);
            Assert.Equal(10, validator.Value);
        }

        [Fact]
        public void Min_ValueBelowMinimum_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.Numeric(3).Min(5));
        }

        [Fact]
        public void Max_ValidValue_ShouldPass()
        {
            var validator = Validator.Numeric(10).Max(20);
            Assert.Equal(10, validator.Value);
        }

        [Fact]
        public void Max_ValueAboveMaximum_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.Numeric(25).Max(20));
        }

        [Fact]
        public void MinMax_ValidRange_ShouldPass()
        {
            var validator = Validator.Numeric(10).MinMax(5, 20);
            Assert.Equal(10, validator.Value);
        }

        [Fact]
        public void MinMax_ValueOutOfRange_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.Numeric(3).MinMax(5, 20));
            Assert.Throws<ValidatorException>(() => Validator.Numeric(25).MinMax(5, 20));
        }

        [Fact]
        public void Positive_ValidPositiveNumber_ShouldPass()
        {
            var validator = Validator.Numeric(15).Positive();
            Assert.Equal(15, validator.Value);
        }

        [Fact]
        public void Positive_NegativeNumber_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.Numeric(-5).Positive());
        }

        [Fact]
        public void Validate_ValidChainedChecks_ShouldPass()
        {
            var result = Validator.Numeric(15)
                .Min(10)
                .Max(20)
                .Positive()
                .Value;

            Assert.Equal(15, result);
        }

        [Fact]
        public void Validate_InvalidChainedChecks_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() =>
                Validator.Numeric(-5).Positive().Min(0));
        }
    }
}
