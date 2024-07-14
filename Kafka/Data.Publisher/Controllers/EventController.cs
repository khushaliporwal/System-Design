using Data.Publisher.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Data.Publisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IPublisher publisher;

        public EventController(IPublisher publisher)
        {
            this.publisher = publisher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string msg)
        {
            await publisher.ProduceAsync(msg);
            return Ok();
        }
    }
}
