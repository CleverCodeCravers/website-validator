using WebsiteValidator.BL.Classes;
using Xunit;

namespace WebsiteValidator.BL.Tests
{
    public class UrlExtractorTests
    {
        [Fact]
        public void Extract_Url()
        {
            string html = "<a href=\"https://github.com\">";

            var extractor = new HtmlAgilityBasedUrlExtractor();
            var urls = extractor.ExtractUrls(html);

            Assert.Single(urls);
            Assert.Equal("https://github.com", urls[0]);
        }
    }
}