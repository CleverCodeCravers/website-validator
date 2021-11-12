using System.Net;

namespace WebsiteValidator.BL.Interfaces
{
    /// <summary>
    /// In this application we are focusing on webpages
    /// </summary>
    public interface IWebpage
    {
        /// <summary>
        /// The absolute url to the resource.
        /// </summary>
        string AbsoluteUrl { get; }

        /// <summary>
        /// The raw content as string.
        /// </summary>
        string RawContent { get; }

        /// <summary>
        /// File size
        /// </summary>
        int ContentSizeInBytes { get; }

        /// <summary>
        /// The HTTP code that was returned.
        /// </summary>
        HttpStatusCode HttpCode { get; }
    }
}