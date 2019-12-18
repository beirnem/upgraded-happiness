using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebServiceXmlParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiveXmlController : ControllerBase
    {
        private readonly ILogger<ReceiveXmlController> _logger;

        public ReceiveXmlController(ILogger<ReceiveXmlController> logger)
        {
            _logger = logger;
        }

        // GET: api/ReceiveXml
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ReceiveXml/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ReceiveXml
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ReceiveXml/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
