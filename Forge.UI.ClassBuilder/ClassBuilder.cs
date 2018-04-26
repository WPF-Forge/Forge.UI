using System;
using System.Linq;
using Forge.UI.Interfaces;
using Forge.UI.Models;

namespace Forge.UI
{
    public class ClassBuilder
    {
        public static Type BuildFromContext(IParserContext context)
        {
            var builder = new ClassRepresentationBuilder();
            
            foreach (var modelDescriptionProperty in context.ModelDescription.Properties)
            {
                if (modelDescriptionProperty is PropertyDescription propertyDescription)
                    builder.WithPropertyDescription(propertyDescription);
            }
            
            foreach (var modelDescriptionProperty in context.ModelDescription.Actions)
            {
                if (modelDescriptionProperty is ActionDescription actionDescription)
                    builder.WithActionDescription(actionDescription);
            }

            builder.WithUsings("Forge.Forms.Annotations");
            
            var toCompile = builder.Build();
            var codeManager = new CodeManager();
            var types = codeManager.GenerateAssembly(toCompile).Result.GetTypes();
            return types.LastOrDefault();
        }
    }
}