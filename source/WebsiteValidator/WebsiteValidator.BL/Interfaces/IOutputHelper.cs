namespace WebsiteValidator.BL.Interfaces
{
    public interface IOutputHelper
    {
        void Write(string name, string[] arrayOfThings);
        void Write(string name, IUrlInformation[] arrayOfThings);
    }
}