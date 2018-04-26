using System;
using System.Linq;
using System.Threading;
using Forge.UI.Interfaces;
using Newtonsoft.Json.Linq;

namespace Forge.UI.Models
{
    public class PropertyDescription : IDescription
    {
        public string Name { get; private set; }

        public string Type { get; private set; }

        private static string ResolveType(JProperty sourceToken)
        {
            return sourceToken.Value.HasValues
                ? sourceToken.Value["type"].Value<string>()
                : sourceToken.Value.Type.ToString().ToLower();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Type)}: {Type}";
        }

        public void FromProperty(JProperty property)
        {
            Name = property.Name;
            Type = ResolveType(property);
        }
    }
}