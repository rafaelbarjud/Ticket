using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
using Ticket.Domain.Models.Validations;
using Ticket.Domain.Exceptions;

namespace Ticket.Domain.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? DateBirth { get; set; }
        public string Phone { get; set; }

        public ICollection<Address> Address { get; set; }

        public bool Validate(User user)
        {

            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(user);

            StringBuilder sb = new StringBuilder();

            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    sb.Append($"{item.ErrorMessage} | ");
                }

                throw new AppException(sb.ToString());
            }

            return true;

        }
    }

    
}
