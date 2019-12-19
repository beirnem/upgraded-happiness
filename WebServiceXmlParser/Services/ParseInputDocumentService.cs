using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using WebServiceXmlParser.Core.Interfaces;

namespace WebServiceXmlParser.Services
{
    public class ParseInputDocumentService : IParseInputDocumentService
    {
        /// <summary>
        /// Parse an Xml document and validate that it has the correct structure, attributes and elements as defined by the business requirements.
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <returns></returns>
        public Task<(int status, string message)> ValidateDocument(XmlDocument xmlDocument)
        {
            
        }

    }
}
