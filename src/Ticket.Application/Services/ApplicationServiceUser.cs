using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Ticket.Application.Interfaces;
using Ticket.Application.Request;
using Ticket.Application.Response;
using Ticket.Domain.Exceptions;
using Ticket.Domain.Interfaces.Services;
using Ticket.Domain.Models;


namespace Ticket.Application.Services
{
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly IServiceUser _serviceUser;
        private readonly IMapper _mapper;
        private readonly ILogger<ApplicationServiceUser> _logger;
        private readonly IApplicationServiceAddress _applicationServiceAddress;

        public ApplicationServiceUser(IServiceUser serviceUser,
            IMapper mapper,
            ILogger<ApplicationServiceUser> logger,
            IApplicationServiceAddress applicationServiceAddress)
        {
            _serviceUser = serviceUser;
            _mapper = mapper;
            _logger = logger;
            _applicationServiceAddress = applicationServiceAddress;
        }

        public ResponseUser Add(RequestUser user)
        {
            try
            {
                _logger.LogInformation("Validating user");

                User newUser = _mapper.Map<User>(user);
                newUser.Validate(newUser);

                _logger.LogInformation("User is valid");

                newUser.Address = _applicationServiceAddress.GetAddress(user.Address).Result;

                _logger.LogInformation("Saving User");
                _serviceUser.Add(newUser);
                _logger.LogInformation("User saved");

                return _mapper.Map<ResponseUser>(newUser);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} | StackTrace {ex.StackTrace}");
                throw new AppException(ex.Message);
            }

        }

        public void Dispose()
        {
            _serviceUser.Dispose();
        }

        public ResponseUser GetById(Guid id)
        {
            var objUser = _serviceUser.GetById(id);
            return _mapper.Map<ResponseUser>(objUser);
        }

        public ResponseUser GetByIdWithAddress(Guid id)
        {
            _logger.LogInformation("Retrieve user ");
            var objUser = _serviceUser.GetByIdWithAddress(id);

            if (objUser == null)
            {
                _logger.LogInformation($"user {id} not found");
                throw new KeyNotFoundException("User not found");
            }

            return _mapper.Map<ResponseUser>(objUser);
        }

        public List<ResponseUser> GetByName(string name)
        {
            _logger.LogInformation("Retrieve user ");

            var objUser = _serviceUser.GetByName(name);

            if (objUser == null || objUser.Count <= 0)
            {
                _logger.LogInformation($"user {name} not found");
                throw new KeyNotFoundException("User not found");
            }

            return _mapper.Map<List<ResponseUser>>(objUser);
        }

        public void Remove(Guid id)
        {
            _logger.LogInformation("Retrieve user for delete");
            var objUser = _serviceUser.GetByIdWithAddress(id);

            if (objUser == null)
            {
                _logger.LogInformation($"user {id} not found");
                throw new KeyNotFoundException("User not found");
            }

            objUser.Address.ToList().ForEach(address =>
            {
                _applicationServiceAddress.Remove(address.Id);
                _logger.LogInformation($"Address removed");
            });

            _serviceUser.Delete(objUser);
            _logger.LogInformation("User removed");
        }

        public ResponseUser Update(RequestUpdateUser user)
        {

            try
            {
                _logger.LogInformation("Validating user");

                User updateUser = _mapper.Map<User>(user);
                updateUser.Validate(updateUser);

                _logger.LogInformation("User is valid");

                updateUser.Address = _applicationServiceAddress.GetAddress(user.Address).Result;

                _logger.LogInformation("Saving User");

                var userUpdated = _serviceUser.GetByIdWithAddress(updateUser.Id);

                List<string> zipCodes = new List<string>();

                userUpdated.Address.ToList().ForEach(address => zipCodes.Add(address.ZipCode));

                updateUser.Address.ToList().ForEach(address =>
                {

                    if (!zipCodes.Contains(address.ZipCode))
                        userUpdated.Address.Add(address);
                });

                userUpdated.Name = updateUser.Name;
                userUpdated.Email = updateUser.Email;
                userUpdated.Phone = updateUser.Phone;
                userUpdated.BirthDate = updateUser.BirthDate;

                _serviceUser.Update(userUpdated);

                _logger.LogInformation("User updated");

                return _mapper.Map<ResponseUser>(userUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} | StackTrace {ex.StackTrace}");
                throw new AppException(ex.Message);
            }
        }
    }
}
