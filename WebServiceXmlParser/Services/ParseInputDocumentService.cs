using System;
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
        public DocumentParseResult ValidateDocument(XmlDocument xmlDocument)
        {
            // 
            try
            {
                // Verify that the document structure is correct.
                XmlSchemaSet schemas = new XmlSchemaSet();
                schemas.Add("", new XmlTextReader("../Core/InputDocumentSchema.xsd"));
                xmlDocument.Validate(InputDocumentValidationEventHandler); // need to use the output from this

                if (xmlDocument.FirstChild.InnerText != "InputDocument")
                {
                    return new DocumentParseResult()
                    {
                        Status = -5,
                        Message = "Invalid document structure"
                    };

                }

                // Check question part b
                // Verify that the Declaration element has the correct Command attribute
                if (xmlDocument.GetElementById("Declaration").HasAttribute("Command") 
                    && xmlDocument.GetElementById("Declaration").GetAttribute("Command") != "DEFAULT")
                {
                    return new DocumentParseResult()
                    {
                        Status = -1,
                        Message = "Invalid command specified"
                    };
                }

                // Check question part c
                // Verify that the Site ID element has the correct Value
                if (xmlDocument.GetElementById("SiteID").InnerText != "DUB")
                {
                    return new DocumentParseResult()
                    {
                        Status = -2,
                        Message = "Invalid site specified"
                    };
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new DocumentParseResult()
            {
                Status = 0,
                Message = "Document is structured correctly"
            };
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
