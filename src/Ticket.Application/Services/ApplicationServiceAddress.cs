using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ticket.Application.Interfaces;
using Ticket.Application.Request;
using Ticket.Application.Response;
using Ticket.Domain.Exceptions;
using Ticket.Domain.Interfaces.Services;
using Ticket.Domain.Models;
using Ticket.Integrations.Interfaces;

namespace Ticket.Application.Services
{
    public class ApplicationServiceAddress : IApplicationServiceAddress
    {
        private readonly IServiceAddress _serviceAddress;
        private readonly IMapper _mapper;
        private readonly ILogger<ApplicationServiceAddress> _logger;
        private readonly IServiceViaCep _serviceViaCep;

        public ApplicationServiceAddress(IServiceAddress serviceAddress,
            IMapper mapper,
            ILogger<ApplicationServiceAddress> logger,
            IServiceViaCep serviceViaCep)
        {
            _logger = logger;
            _serviceAddress = serviceAddress;   
            _mapper = mapper; 
            _serviceViaCep = serviceViaCep;
        }

        public void Dispose()
        {
            _serviceAddress.Dispose();
        }

        public async Task<List<Address>> GetAddress(List<RequestAddress> addresses)
        {
            _logger.LogInformation("validating address");

            try
            {
                Address newAdress = new Address();
                List<Address> adressList = _mapper.Map<List<Address>>(addresses);

                newAdress.Validate(adressList);

                _logger.LogInformation("Address is valid");

                _logger.LogInformation("searching address");
                foreach (var item in adressList)
                {
                    var result = _serviceViaCep.Search(item.ZipCode);
                    if (result.ZipCode != null)
                    {
                        item.City = result.City;
                        item.Complement = result.Complement;
                        item.Ddd = result.Ddd;
                        item.Gia = result.Gia;
                        item.Ibge = result.Ibge;
                        item.Neighborhood = result.Neighborhood;
                        item.Siafi = result.Siafi;
                        item.State = result.State;
                        item.Street = result.Street;
                    }
                    else
                        throw new AppException("ZipCode not found");
                }

                _logger.LogInformation("searching completed");

                return await Task.Run(() => adressList);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
            
        }

        public List<ResponseAddress> GetAddressByUserId(Guid userId)
        { 
            var addressList = _mapper.Map<List<ResponseAddress>>(_serviceAddress.GetAddressByUserId(userId));

            if (addressList == null && addressList.Count <= 0)
                throw new KeyNotFoundException("Address not found");

            return addressList;
        }

        public void Remove(Guid id)
        {

            _logger.LogInformation("Retrieve address for delete");
            var address = _serviceAddress.GetById(id);

            if (address == null)
            {
                _logger.LogInformation($"address {id} not found");
                throw new KeyNotFoundException("Address not found");
            }

            _serviceAddress.Delete(address);

            _logger.LogInformation("Address removed");
        }
    }
}
