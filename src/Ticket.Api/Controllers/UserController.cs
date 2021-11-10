using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ticket.Application.Interfaces;
using Ticket.Application.Request;
using Newtonsoft.Json;
using System;

namespace Ticket.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IApplicationServiceUser _applicationService;
        private readonly ILogger<UserController> _logger;

        public UserController(IApplicationServiceUser applicationServiceUser, ILogger<UserController> logger)
        {
            _applicationService = applicationServiceUser;
            _logger = logger;

        }

        [HttpPost]
        public ActionResult Post([FromBody] RequestUser user)
        {
            _logger.LogInformation($"Started inclusion of user: {JsonConvert.SerializeObject(user)}");

            return Ok(_applicationService.Add(user));
             
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult GetById(Guid id)
        {
            _logger.LogInformation($"Get user of id: {id}");

            return Ok(_applicationService.GetByIdWithAddress(id));

        }

        [Route("{name}")]
        [HttpGet]
        public ActionResult GetByName(string name)
        {
            _logger.LogInformation($"Get user of id: {name}");

            return Ok(_applicationService.GetByName(name));

        }

        [Route("")]
        [HttpPatch]
        public ActionResult Update([FromBody] RequestUpdateUser user)
        {
            _logger.LogInformation($"Started update of user: {JsonConvert.SerializeObject(user)}");

            return Ok(_applicationService.Update(user));

        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _logger.LogInformation($"Started delete of user: {id}");
            _applicationService.Remove(id);
            return NoContent();

        }
    }
}
