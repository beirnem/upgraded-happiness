using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebServiceXmlParser.Core;
using WebServiceXmlParser.Core.Interfaces;

namespace WebServiceXmlParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiveXmlController : ControllerBase
    {
        private readonly ILogger<ReceiveXmlController> _logger;
        private readonly IParseInputDocument _parseInputDocument;

        public ReceiveXmlController(ILogger<ReceiveXmlController> logger, IParseInputDocument parseInputDocument)
        {
            _logger = logger;
            _parseInputDocument = parseInputDocument;

        }

        // GET: api/ReceiveXml
        [HttpGet]
        public async Task<IActionResult> Get(string xmlDoc)
        {
            var result = await _parseInputDocument.ValidateDocument(xmlDoc);
            switch (result.status)
            {
                case 0:
                    {
                        var message = "Document structured correctly";
                        return Ok(message);
                    }
                case -1:
                    {
                        var errorMessage = "Invalid Declaration Command specified";
                        _logger.LogError(LoggingEvents.InvalidCommand, errorMessage, result.message);
                        return StatusCode(422, errorMessage);
                    }
                case -2:
                    {
                        var errorMessage = "Invalid Site specified";
                        _logger.LogError(LoggingEvents.InvalidSite, "Invalid Site specified", result.message);
                        return StatusCode(422, errorMessage);
                    }
                default:
                    // This case is a catch all, in case a non-handled result is returned, so that we don't automatically assume the document is correct.
                    return BadRequest();
            }
        }
    }
}
