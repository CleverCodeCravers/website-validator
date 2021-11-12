using System.Threading.Tasks;
using WebsiteValidator.BL.Classes;
using WebsiteValidator.BL.Interfaces;

namespace WebsiteValidator.BL.ExtensionMethods
{
    public static class WebpageExtensionMethods 
    {
        public static string[] ExtractUrls(this Task<IWebpage> webpage)
        {
            IUrlExtractor extractor = new HtmlAgilityBasedUrlExtractor();
            return extractor.ExtractUrls(webpage.Result.RawContent);
        }
    }
}