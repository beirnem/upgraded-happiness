using System.Threading.Tasks;
using System.Xml;
using WebServiceXmlParser.Core.Models;

namespace WebServiceXmlParser.Core.Interfaces
{
    public interface IParseInputDocumentService
    {
        public Task<DocumentParseResult> ValidateDocument(XmlDocument xmlDocument);
    }
}
