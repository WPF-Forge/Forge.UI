using System;
using System.Collections.Generic;
using Forge.UI.Models;

namespace Forge.UI
{
    internal class ClassRepresentationBuilder
    {
        private readonly string _className =
            Nanoid.Nanoid.Generate("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 32);

        private string Representation { get; set; } = "";
        private List<string> Usings { get; } = new List<string>{"System"};
        private List<string> Properties { get; } = new List<string>();
        private List<string> ClassAttributes { get; } = new List<string>();
        
        private void AddClassHeader()
        {
            foreach (var @using in Usings)
            {
                WriteLine($"using {@using};");
            }
            
            WriteLine("");
            AddClassAttributes();
            WriteLine($"public class {_className} {{");
        }

        private void AddClassAttributes()
        {
            foreach (var classAttribute in ClassAttributes)
            {
                WriteLine(classAttribute);
            }
        }

        private void AddProperties()
        {
            foreach (var property in Properties)
            {
                WriteLine(property);
            }
        }

        private void AddFooter()
        {
            WriteLine("}");
        }

        private void WriteLine(string toWrite)
        {
            Representation += toWrite + Environment.NewLine;
        }

        public ClassRepresentationBuilder WithUsings(params string[] usings)
        {
            Usings.AddRange(usings);
            return this;
        }
        
        public ClassRepresentationBuilder WithActionDescription(ActionDescription actionDescription)
        {
            ClassAttributes.Add($"[Action(\"{actionDescription.Name}\", \"{actionDescription.Name}\")]");
            return this;
        }

        public ClassRepresentationBuilder WithPropertyDescription(PropertyDescription propertyDescription)
        {
            Properties.Add($"    public {ResolvePropertyName(propertyDescription)} {propertyDescription.Name} {{ get; set; }}");
            return this;
        }

        private static string ResolvePropertyName(PropertyDescription propertyDescription)
        {
            var name = propertyDescription.Type;
            return name == "integer" ? "int" : name;
        }

        public string Build()
        {
            AddClassHeader();
            AddProperties();
            AddFooter();
            
            return Representation;
        }
    }
}