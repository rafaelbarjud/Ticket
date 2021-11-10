using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ticket.Application.Interfaces;
using Ticket.Application.Request;
using Newtonsoft.Json;


namespace Ticket.Api.Controllers
{
    [Route("api/[controller]")]
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
            _logger.LogInformation($"Iniciando a inclusão do usuário: {JsonConvert.SerializeObject(user)}");

            _applicationService.Add(user);
            return Ok();
        }
    }
}
