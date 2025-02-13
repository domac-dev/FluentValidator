using FluentValidator;
using FluentValidator.Exceptions;

namespace ValidatorTests
{
    public class StringValidatorTests
    {
        [Fact]
        public void MinLength_ValidString_ShouldPass()
        {
            var validator = Validator.String("Hello").MinLength(3);
            Assert.Equal("Hello", validator.Value);
        }

        [Fact]
        public void MinLength_ShortString_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.String("Hi").MinLength(5));
        }

        [Fact]
        public void MaxLength_ValidString_ShouldPass()
        {
            var validator = Validator.String("Hello").MaxLength(10);
            Assert.Equal("Hello", validator.Value);
        }

        [Fact]
        public void MaxLength_LongString_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.String("Hello World").MaxLength(5));
        }

        [Fact]
        public void MinMaxLength_ValidString_ShouldPass()
        {
            var validator = Validator.String("Hello").MinMaxLength(3, 10);
            Assert.Equal("Hello", validator.Value);
        }

        [Fact]
        public void MinMaxLength_OutOfRange_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.String("Hi").MinMaxLength(3, 10));
            Assert.Throws<ValidatorException>(() => Validator.String("Hello World").MinMaxLength(3, 10));
        }

        [Fact]
        public void NullOrWhiteSpace_ValidString_ShouldPass()
        {
            var validator = Validator.String("Hello").NullOrWhiteSpace();
            Assert.Equal("Hello", validator.Value);
        }

        [Fact]
        public void NullOrWhiteSpace_NullOrWhitespace_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.String("   ").NullOrWhiteSpace());
            Assert.Throws<ValidatorException>(() => Validator.String("").NullOrWhiteSpace());
            Assert.Throws<ValidatorException>(() => Validator.String(null).NullOrWhiteSpace());
        }

        [Fact]
        public void Regex_ValidPattern_ShouldPass()
        {
            var validator = Validator.String("abc123").MatchesPattern(@"^[a-z0-9]+$");
            Assert.Equal("abc123", validator.Value);
        }

        [Fact]
        public void Regex_InvalidPattern_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.String("abc-123").MatchesPattern(@"^[a-z0-9]+$"));
        }

        [Fact]
        public void IPAddress_ValidIP_ShouldPass()
        {
            var validator = Validator.String("192.168.1.1").IPAddress();
            Assert.Equal("192.168.1.1", validator.Value);
        }

        [Fact]
        public void IPAddress_InvalidIP_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.String("999.999.999.999").IPAddress());
        }

        [Fact]
        public void EmailAddress_ValidEmail_ShouldPass()
        {
            var validator = Validator.String("test@example.com").EmailAddress();
            Assert.Equal("test@example.com", validator.Value);
        }

        [Fact]
        public void EmailAddress_InvalidEmail_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() => Validator.String("invalid-email").EmailAddress());
        }

        [Fact]
        public void Validate_ValidEmailAndLength_ShouldPass()
        {
            var result = Validator.String("test@example.com")
                .EmailAddress()
                .MinLength(5)
                .MaxLength(50)
                .Value;

            Assert.Equal("test@example.com", result);
        }

        [Fact]
        public void Validate_NullOrWhitespace_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() =>
                Validator.String("   ").NullOrWhiteSpace());
        }

        [Fact]
        public void Validate_InvalidEmail_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() =>
                Validator.String("invalid-email").NullOrWhiteSpace().EmailAddress());
        }

        [Fact]
        public void Validate_LengthOutOfBounds_ShouldThrowException()
        {
            Assert.Throws<ValidatorException>(() =>
                Validator.String("short").MinMaxLength(10, 20));
        }

        [Fact]
        public void Validate_ValidChainedChecks_ShouldPass()
        {
            var result = Validator.String("valid.email@example.com")
                .EmailAddress()
                .MinMaxLength(10, 50)
                .MatchesPattern(@"^[a-zA-Z0-9.@]+$")
                .Value;

            Assert.Equal("valid.email@example.com", result);
        }

    }
}
