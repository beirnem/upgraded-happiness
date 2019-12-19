using System.Threading.Tasks;
using System.Xml;

namespace WebServiceXmlParser.Core.Interfaces
{
    public interface IParseInputDocumentService
    {
        public Task<(int status, string message)> ValidateDocument(XmlDocument xmlDocument);
    }
}
