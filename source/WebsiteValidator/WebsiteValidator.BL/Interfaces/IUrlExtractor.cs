namespace WebsiteValidator.BL.Interfaces
{
    /// <summary>
    /// We need to extract the urls.
    /// </summary>
    public interface IUrlExtractor
    {
        string[] ExtractUrls(string pageContents);
    }
}