using System.Net;

namespace WebsiteValidator.BL.Interfaces
{
    public interface IUrlInformation
    {
        string Url { get; }
        string[] Links { get; }
        int ContentSizeInBytes { get; }
        HttpStatusCode HttpResponseCode { get; }
        string Content { get; }
        string ContentWithoutHtml { get; }
    }


}