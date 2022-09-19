using FluentValidation;
using tandem_be_challenge.DTOs;

namespace tandem_be_challenge.Validations
{
    public class CreateUserRequestValidator : AbstractValidator<UserRequestDTO>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(dto => dto.EmailAddress).EmailAddress().WithMessage("Email Address is not valid");
            RuleFor(dto => dto.FirstName).Length(1, 10).WithMessage("FirstName length should be between 1 and 10");
            RuleFor(dto => dto.MiddleName).Length(1, 10).WithMessage("MiddleName length should be between 1 and 10"); ;
            RuleFor(dto => dto.LastName).Length(1, 10).WithMessage("LastName length should be between 1 and 10"); ;
            RuleFor(dto => dto.PhoneNumber).Length(8, 13).WithMessage("PhoneNumber length should be between 8 and 13");
        }
    }
}
