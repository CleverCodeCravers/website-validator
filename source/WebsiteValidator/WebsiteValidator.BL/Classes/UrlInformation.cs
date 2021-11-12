using System.Net;
using WebsiteValidator.BL.Interfaces;

namespace WebsiteValidator.BL.Classes
{
    public class UrlInformation : IUrlInformation
    {
        public string Url { get; }
        public string[] Links { get; }
        public int ContentSizeInBytes { get; }
        public HttpStatusCode HttpResponseCode { get; }
        public string Content { get; }
        public string ContentWithoutHtml { get; }

        public UrlInformation(string url, string[] links, HttpStatusCode httpResponseCode, string content, string contentWithoutHtml, int contentSizeInBytes)
        {
            Url = url;
            Links = links;
            HttpResponseCode = httpResponseCode;
            Content = content;
            ContentWithoutHtml = contentWithoutHtml;
            ContentSizeInBytes = contentSizeInBytes;
        }
    }
}