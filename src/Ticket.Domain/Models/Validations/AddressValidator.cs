using FluentValidation;
using System;
using System.Collections.Generic;

namespace Ticket.Domain.Models.Validations
{
    internal class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            List<string> categorys = new List<string>() { "Residential", "Commercial" };
            RuleFor(c => c.Category)
                .NotEmpty().WithMessage("Category is required")
                .Must(x => categorys.Contains(x)).WithMessage("Please only use: " + String.Join(",", categorys));

            RuleFor(c => c.ZipCode)
                .NotEmpty().WithMessage("ZipCode is required")
                .Matches(@"\d{5}-\d{3}").WithMessage("Cep is invalid");
        }
    }
}
