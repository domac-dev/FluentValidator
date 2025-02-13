### Overview

**FluentValidator** is a simple .NET library designed for performing common validation checks using a fluent API.
Here’s a quick example of how you can use this library to perform validation checks when setting an encapsulated property value.

```csharp

public string Email
{
    get => _email;
    set => _email = Validator.String(value).NullOrWhiteSpace().EmailAddress().Value;          
}
```

The library comes with a set of common validators such as `numeric`, `string` etc. You can create your own custom validators, but you can also extend the existing ones as seen in the example below.

```csharp
public static class DateTimeValidatorExtensions
{
   public static bool IsWeekend(this IDateTimeValidator validator, DateTime dateTime)
   {
       return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
   }
}
```
```csharp
public interface ICustomObjectValidator<TValue> : IValidator<ICustomObjectValidator<TValue>, TValue> where TValue : class
{
   ICustomObjectValidator<TValue> IsValid();
}

public class CustomObjectValidator<TValue>(TValue? input, string? paramName = null, bool allowNull = false)
   : ValidatorBase<ICustomObjectValidator<TValue>, TValue>(input, paramName, allowNull), ICustomObjectValidator<TValue> where TValue : class
{
   public ICustomObjectValidator<TValue> IsValid()
   {
       //validation logic here
       return this;
   }
}
```
