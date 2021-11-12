using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebsiteValidator.BL.Interfaces;

namespace WebsiteValidator.BL.Classes
{
    public class DownloadAWebpage : IDownloadAWebpage
    {
        private bool ignoreSsl;

        public DownloadAWebpage(bool ignoreSsl)
        {
            this.ignoreSsl = ignoreSsl;
        }

        public bool ForceBadCertificate { get; set; }

        public async Task<IWebpage> Download(string url)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                if (ignoreSsl)
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                }

                if (ForceBadCertificate && !ignoreSsl)
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return false; };
                }

                using (var client = new HttpClient(httpClientHandler))
                {
                    // Make request here.
                    var response = await client.GetAsync(url);
                    var pageContents = await response.Content.ReadAsStringAsync();
                    return new Webpage(url, pageContents, pageContents.Length, response.StatusCode);
                }
            }
        }
    }
}