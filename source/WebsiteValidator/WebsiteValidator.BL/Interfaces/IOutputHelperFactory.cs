namespace WebsiteValidator.BL.Interfaces
{
    public interface IOutputHelperFactory
    {
        IOutputHelper Get(bool human, string outputFilename);
    }
}