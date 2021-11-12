using System.IO;
using Newtonsoft.Json;
using WebsiteValidator.BL.Interfaces;

namespace WebsiteValidator.BL.Classes
{
    public class JsonFileOutputHelper : IOutputHelper
    {
        private readonly string _outputFilename;

        public JsonFileOutputHelper(string outputFilename)
        {
            _outputFilename = outputFilename;
        }

        public void Write(string name, string[] arrayOfThings)
        {
            var json = JsonConvert.SerializeObject(arrayOfThings, Formatting.Indented);
            File.WriteAllText(_outputFilename, json);
        }

        public void Write(string name, IUrlInformation[] arrayOfThings)
        {
            var json = JsonConvert.SerializeObject(arrayOfThings, Formatting.Indented);
            File.WriteAllText(_outputFilename, json);
        }
    }
}