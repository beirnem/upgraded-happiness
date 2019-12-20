using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using WebServiceXmlParser.Core.Interfaces;
using WebServiceXmlParser.Core.Models;

namespace WebServiceXmlParser.Services
{
    public class ParseInputDocumentService : IParseInputDocumentService
    {
        /// <summary>
        /// Parse an Xml document and validate that it has the correct structure, attributes and elements as defined by the business requirements.
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <returns></returns>
        public async Task<DocumentParseResult> ValidateDocument(XmlDocument xmlDocument)
        {
            // 
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", new XmlTextReader("../Core/InputDocumentSchema.xsd"));
            xmlDocument.Validate(InputDocumentValidationEventHandler);
            if (xmlDocument.DocumentElement.InnerText != "InputDocument")
            { 
                return new DocumentParseResult()
                {
                    Status = -5,
                    Message = "Invalid document structure"
                }; ;
            }

            // Verify that the document structure is correct.

            // Verify that the Declaration element has the correct Command attribute

            // Verify that the Site ID element has the correct Value
            
        }

        private void InputDocumentValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                Console.Write("WARNING: ");
                Console.WriteLine(e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                Console.Write("ERROR: ");
                Console.WriteLine(e.Message);
            }

        }

    }
}
