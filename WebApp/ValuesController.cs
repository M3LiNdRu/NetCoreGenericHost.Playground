using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEnumerable<string> _values;

        public ValuesController()
        {
            _values = new List<string> { "value1", "value2" };
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_values);
        }
    }
}
