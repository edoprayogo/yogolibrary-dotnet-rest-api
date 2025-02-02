using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CustomerController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{customerId:guid}")]
        public async Task<IActionResult> GetOwnerById(Guid customerId, CancellationToken cancellationToken)
        {
            var ownerDto = await _serviceManager.CustomerService.GetByIdAsync(customerId, cancellationToken);
            return Ok(ownerDto);
        }
    }
}
