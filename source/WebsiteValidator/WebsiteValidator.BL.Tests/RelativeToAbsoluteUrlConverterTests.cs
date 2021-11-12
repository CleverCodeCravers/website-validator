using System.Security.Cryptography.X509Certificates;
using WebsiteValidator.BL.Classes;
using WebsiteValidator.BL.Interfaces;
using Xunit;

namespace WebsiteValidator.BL.Tests
{
    public class UrlToAbsolutUrlConverterTests
    {
        [Fact]
        public void Einfache_Umwandlung()
        {
            var relativeUrl = "/helloWorld.php";
            var baseUrl = "https://whatever.com";

            var converter = new UrlToAbsolutUrlConverter();
            var result = converter.ToAbsoluteUrl(baseUrl, relativeUrl);

            Assert.Equal("https://whatever.com/helloWorld.php", result);
        }

        [Fact]
        public void Wenn_absolute_URL_uebergeben_wird_dann_nichts_tun()
        {
            var baseUrl = "https://whatever.com";

            var converter = new UrlToAbsolutUrlConverter();
            var result = converter.ToAbsoluteUrl(baseUrl, "https://whatever.com/test-fuer-unsere-seite");

            Assert.Equal("https://whatever.com/test-fuer-unsere-seite", result);
        }

        [Fact]
        public void Wenn_die_URL_auf_Slash_endet_dann_Slash_entfernen()
        {
            var baseUrl = "https://whatever.com";

            var converter = new UrlToAbsolutUrlConverter();
            var result = converter.ToAbsoluteUrl(baseUrl, "https://whatever.com/test-fuer-unsere-seite/");

            Assert.Equal("https://whatever.com/test-fuer-unsere-seite", result);
        }

    }
}