using application.Entities;
using application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Producer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductorController : ControllerBase
    {

        private readonly ILogger<ProductorController> _logger;
        private readonly IProductService _service;

        public ProductorController(ILogger<ProductorController> logger, IProductService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<int> PostAsync([FromBody] Product resquest)
        {
            return await _service.GenerateAsync(resquest);
        }
    }
}
