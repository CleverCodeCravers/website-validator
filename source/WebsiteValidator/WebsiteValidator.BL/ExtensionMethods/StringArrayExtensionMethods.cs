using WebsiteValidator.BL.Classes;

namespace WebsiteValidator.BL.ExtensionMethods
{
    public static class StringArrayExtensionMethods
    {
        public static string[] ToAbsoluteUrls(this string[] links, string baseUrl)
        {
            var converter = new UrlToAbsolutUrlConverter();
            return converter.ToAbsoluteUrl(baseUrl, links);
        }
    }
}