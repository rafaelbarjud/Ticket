using FluentValidation;

namespace Ticket.Domain.Models.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("A valid email is required");

            RuleFor(c => c.Phone)
                .Matches(@"\([1-9]\d\)\s9?\d{4}-\d{4}").WithMessage("Phone is invalid")
                .When(c => c.Phone != null);
        }
    }
}
