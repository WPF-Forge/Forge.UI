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
                    var model = JsonConvert.DeserializeObject<dynamic>(streamReader.ReadToEnd());
                    var modelDescription = new ModelDescription();
                    
                    foreach (var jProperty in model.properties.Properties())
                    {
                        modelDescription.Properties.Add(new PropertyDescription(jProperty));
                    }

                    foreach (var jProperty in model.actions.Properties())
                    {
                        modelDescription.Actions.Add(new ActionDescription(jProperty));
                    }
                }
            }

            Console.ReadLine();
        }
    }
}