using WebsiteValidator.BL.Interfaces;

namespace WebsiteValidator.BL.Classes
{
    public class OutputHelperFactory : IOutputHelperFactory
    {
        public IOutputHelper Get(bool human, string outputFilename)
        {
            if (human)
                return new HumanReadableConsoleOutputHelper();

            if (string.IsNullOrWhiteSpace(outputFilename))
            {
                return new JsonConsoleOutputHelper();
            }
            
            return new JsonFileOutputHelper(outputFilename);
        }
    }
}