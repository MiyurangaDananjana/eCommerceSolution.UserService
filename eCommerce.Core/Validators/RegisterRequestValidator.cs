using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;
public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        //Email
        RuleFor(temp => temp.Email).NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address format")
            .Length(1,50).WithMessage("Person Name should be 1 to 50 characters long");

        //Password
        RuleFor(temp => temp.Password).NotEmpty()
            .WithMessage("Password is required");

        //PersonName 
        RuleFor(temp => temp.PersonName).NotEmpty()
           .WithMessage("PersonName is required");

        //Gender
        RuleFor(temp => temp.Gender).IsInEnum()
          .WithMessage("Invalid Gender is options");
    }
}

