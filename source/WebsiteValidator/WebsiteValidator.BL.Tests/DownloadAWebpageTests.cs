using System;
using System.Net;
using WebsiteValidator.BL.Classes;
using Xunit;
using Xunit.Abstractions;

namespace WebsiteValidator.BL.Tests
{
    public class DownloadAWebpageTests
    {

        /// <summary>
        /// This is not exactly a unit test. It will check if the download functionality works
        /// by trying to download a sample page from github which is placed in the
        /// github pages site.
        /// </summary>
        [Fact]
        public async void Downloading_a_webpage_with_good_certificate_works()
        {
            string url = "https://stho32.github.io/website-validator/can_download_sample.html";

            var downloader = new DownloadAWebpage(false);
            var result = await downloader.Download(url);

            Assert.Equal(HttpStatusCode.OK, result.HttpCode);
            Assert.Contains("automated test", result.RawContent);
        }

        [Fact]
        public void Downloading_a_webpage_with_bad_certificate_doesnt_work()
        {
            string url = "https://stho32.github.io/website-validator/can_download_sample.html";

            var downloader = new DownloadAWebpage(false);
            downloader.ForceBadCertificate = true;

            Assert.Throws<AggregateException>(() =>
            {
                downloader.Download(url).Wait();
            });
        }

        [Fact]
        public async void Downloading_a_webpage_with_bad_certificate_but_us_ignoring_it_works()
        {
            string url = "https://stho32.github.io/website-validator/can_download_sample.html";

            var downloader = new DownloadAWebpage(true);
            var result = await downloader.Download(url);

            Assert.Equal(HttpStatusCode.OK, result.HttpCode);
        }
    }
}
