using System.Net;
using WebsiteValidator.BL.Interfaces;

namespace WebsiteValidator.BL.Classes
{
    public class Webpage : IWebpage
    {
        public string AbsoluteUrl { get; }
        public string RawContent { get; }
        public int ContentSizeInBytes { get; }
        public HttpStatusCode HttpCode { get; }

        public Webpage(string absoluteUrl, string rawContent, int contentSizeInBytes, HttpStatusCode httpCode)
        {
            AbsoluteUrl = absoluteUrl;
            RawContent = rawContent;
            ContentSizeInBytes = contentSizeInBytes;
            HttpCode = httpCode;
        }
    }
}