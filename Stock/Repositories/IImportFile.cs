using System.Net;
using System.Web;
using Stock.GlobalClass;

namespace Stock.Repositories
{
    public interface IImportFile
    {
        HttpStatusCode Upload(string securityID, FileUploadType fileType, HttpRequest httpRequest);
    }
}
