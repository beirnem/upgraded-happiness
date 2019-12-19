using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceXmlParser.Core.Interfaces
{
    public interface IParseInputDocumentService
    {
        public Task<(int status, string message)> ValidateDocument(string xmlDocument);
    }
}
