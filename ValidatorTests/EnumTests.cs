using FluentValidator;
using FluentValidator.Exceptions;

namespace ValidatorTests
{
    public class EnumValidatorTests
    {
        private enum TestEnum
        {
            ValueOne,
            ValueTwo,
            ValueThree
        }

        [Fact]
        public void Defined_ValidValue_ShouldPass()
        {
            var validator = Validator.Enum<TestEnum>(TestEnum.ValueOne).Defined(TestEnum.ValueOne, TestEnum.ValueTwo);
            Assert.Equal(TestEnum.ValueOne, validator.Value);
        }

        [Fact]
        public void Defined_InvalidValue_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.Enum<TestEnum>(TestEnum.ValueThree).Defined(TestEnum.ValueOne, TestEnum.ValueTwo));
        }

        [Fact]
        public void Defined_ValidDefinedEnum_ShouldPass()
        {
            var validator = Validator.Enum<TestEnum>(TestEnum.ValueTwo).Defined();
            Assert.Equal(TestEnum.ValueTwo, validator.Value);
        }

        [Fact]
        public void Defined_InvalidDefinedEnum_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.Enum<TestEnum>((TestEnum)100).Defined());
        }

        [Fact]
        public void NotDefined_ValidNotDefined_ShouldPass()
        {
            var validator = Validator.Enum<TestEnum>(TestEnum.ValueThree).NotDefined(TestEnum.ValueOne, TestEnum.ValueTwo);
            Assert.Equal(TestEnum.ValueThree, validator.Value);
        }

        [Fact]
        public void NotDefined_InvalidNotDefined_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.Enum<TestEnum>(TestEnum.ValueOne).NotDefined(TestEnum.ValueOne, TestEnum.ValueTwo));
        }

        [Fact]
        public void NotDefined_ValidNotDefinedEnum_ShouldPass()
        {
            var validator = Validator.Enum<TestEnum>((TestEnum)100).NotDefined();
            Assert.Equal((TestEnum)100, validator.Value);
        }

        [Fact]
        public void NotDefined_InvalidNotDefinedEnum_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.Enum<TestEnum>(TestEnum.ValueTwo).NotDefined());
        }
    }
}
