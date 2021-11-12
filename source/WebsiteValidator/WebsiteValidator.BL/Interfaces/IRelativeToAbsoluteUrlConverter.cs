namespace WebsiteValidator.BL.Interfaces
{
    public interface IUrlToAbsolutUrlConverter
    {
        string ToAbsoluteUrl(string baseUrl, string relativeUrl);
    }
}