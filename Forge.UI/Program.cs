using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Forge.UI.Interfaces;
using Forge.UI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Forge.UI
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var currentDir = new DirectoryInfo("./");


            Console.ReadLine();
        }

        public static object UseParser<T>(T parser, string filePath) where T : IParser
        {
            using (var streamReader = new FileInfo(filePath).OpenText())
            {
                var modelDescription = ProcessFile(streamReader);
                var context = BuildContext(modelDescription);
                return parser.Parse(context);
            }
        }

        private static IParserContext BuildContext(IModelDescription description)
        {
            return new ParserContext(description, Assembly.GetExecutingAssembly().GetTypes()
                .Where(i => i.Namespace != null && i.Namespace == "Forge.UI.Actions" &&
                            typeof(IAction).IsAssignableFrom(i)).Select(Activator.CreateInstance)
                .Cast<IAction>().ToLookup(i => i.Key));
        }

        private static ModelDescription ProcessFile(TextReader streamReader)
        {
            var model = JsonConvert.DeserializeObject<dynamic>(streamReader.ReadToEnd());
            var modelDescription = new ModelDescription
            {
                Name = model?.name,
                Properties = CreateDescriptionFrom<PropertyDescription>(model?.properties),
                Actions = CreateDescriptionFrom<ActionDescription>(model?.actions),
                Triggers = CreateDescriptionFrom<TriggerDescription>(model?.triggers)
            };
            return modelDescription;
        }

        private static IEnumerable<T> CreateDescriptionFrom<T>(dynamic properties) where T : IDescription
        {
            if (properties == null) yield break;

            foreach (var jProperty in properties.Properties())
            {
                yield return ResolveDescription<T>(jProperty);
            }
        }

        private static IDescription ResolveDescription<T>(JProperty property) where T : IDescription
        {
            var description = Activator.CreateInstance<T>();
            description.FromProperty(property);
            return description;
        }
    }
}