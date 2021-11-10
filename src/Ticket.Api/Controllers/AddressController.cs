using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Ticket.Application.Interfaces;

namespace Ticket.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IApplicationServiceAddress _applicationService;
        private readonly ILogger<AddressController> _logger;

        public AddressController(IApplicationServiceAddress applicationServiceUser, ILogger<AddressController> logger)
        {
            _applicationService = applicationServiceUser;
            _logger = logger;
        }

        [Route("user/{id}")]
        [HttpGet]
        public ActionResult GetById(Guid id)
        {
            _logger.LogInformation($"Get adress of user with id: {id}");
            return Ok(_applicationService.GetAddressByUserId(id));
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult DeleteById(Guid id)
        {
            _logger.LogInformation($"Started delete of address: {id}");
            _applicationService.Remove(id);
            return NoContent();
        }
    }
}
