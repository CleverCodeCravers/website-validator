using System;
using Newtonsoft.Json;
using WebsiteValidator.BL.Interfaces;

namespace WebsiteValidator.BL.Classes
{
    public class JsonConsoleOutputHelper : IOutputHelper
    {
        public void Write(string name, string[] arrayOfThings)
        {
            var json = JsonConvert.SerializeObject(arrayOfThings, Formatting.Indented);
            Console.WriteLine(json);
        }

        public void Write(string name, IUrlInformation[] arrayOfThings)
        {
            var json = JsonConvert.SerializeObject(arrayOfThings, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}