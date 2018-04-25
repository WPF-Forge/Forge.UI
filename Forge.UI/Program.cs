using System;
using System.IO;
using Forge.UI.Models;
using Newtonsoft.Json;

namespace Forge.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var currentDir = new DirectoryInfo("./");

            foreach (var fileInfo in currentDir.GetFiles("M*.json"))
            {
                Console.WriteLine(fileInfo.Name);

                using (var streamReader = fileInfo.OpenText())
                {
                    var model = JsonConvert.DeserializeObject<ModelDescription>(streamReader.ReadToEnd());

                    foreach (var jProperty in model.Properties.Properties())
                    {
                        Console.WriteLine(new PropertyDescription(jProperty));
                    }
                }
            }

            Console.ReadLine();
        }
    }
}