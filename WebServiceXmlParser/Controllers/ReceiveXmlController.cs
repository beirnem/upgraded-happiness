﻿using System.Threading.Tasks;
using System.Xml;
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
        private readonly IParseInputDocumentService _parseInputDocument;

        public ReceiveXmlController(ILogger<ReceiveXmlController> logger, IParseInputDocumentService parseInputDocument)
        {
            _logger = logger;
            _parseInputDocument = parseInputDocument;

        }

        // POST: api/ReceiveXml
        [HttpPost]
        [ActionName("XMLMethod")]
        public async Task<IActionResult> Post([FromBody]object value)
        {
            var xmlDoc = (XmlDocument)value;
            var result = _parseInputDocument.ValidateDocument(xmlDoc);
            switch (result.Status)
            {
                case 0:
                    {
                        var message = "Document structured correctly";
                        _logger.LogInformation(LoggingEvents.ValidStructure, message);
                        return Ok(message);
                    }
                case -1:
                    {
                        var errorMessage = "Invalid Declaration Command specified";
                        _logger.LogError(LoggingEvents.InvalidCommand, errorMessage, result.Message);
                        return StatusCode(422, errorMessage);
                    }
                case -2:
                    {
                        var errorMessage = "Invalid Site specified";
                        _logger.LogError(LoggingEvents.InvalidSite, "Invalid Site specified", result.Message);
                        return StatusCode(422, errorMessage);
                    }
                default:
                    // This case is a catch all, in case a non-handled result is returned, so that we don't automatically assume the document is correct.
                    return BadRequest();
            }
        }
    }
}
