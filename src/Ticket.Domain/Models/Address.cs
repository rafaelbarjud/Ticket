using FluentValidation.Results;
using System.Collections.Generic;
using System.Text;
using Ticket.Domain.Exceptions;
using Ticket.Domain.Models.Validations;
using Newtonsoft.Json;

namespace Ticket.Domain.Models
{
    public  class Address : BaseEntity
    {
        [JsonProperty("cep")]
        public string ZipCode { get; set; }
        public string Category { get; set; }
        [JsonProperty("logradouro")]
        public string Street { get; set; }
        [JsonProperty("complemento")]
        public string Complement { get; set; }
        [JsonProperty("bairro")]
        public string Neighborhood { get; set; }
        [JsonProperty("localidade")]
        public string City { get; set; }
        [JsonProperty("uf")]
        public string State { get; set; }
        [JsonProperty("ibge")]
        public string Ibge { get; set; }
        [JsonProperty("gia")]
        public string Gia { get; set; }
        [JsonProperty("ddd")]
        public string Ddd { get; set; }
        [JsonProperty("siafi")]
        public string Siafi { get; set; }

        public User User { get; set; }

        public bool Validate(List<Address> adresses)
        {

            AddressValidator validator = new AddressValidator();

            adresses.ForEach(ad => {
                ValidationResult result = validator.Validate(ad);

                if (!result.IsValid)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var item in result.Errors)
                    {
                        sb.Append($"[{item.PropertyName}] - {item.ErrorMessage} | ");
                    }

                    throw new AppException(sb.ToString());
                }
            });

            return true;

        }

    }
}
