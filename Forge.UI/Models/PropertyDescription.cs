using System;
using System.Linq;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace Forge.UI.Models
{
    public class PropertyDescription
    {
        public string Name { get; }

        public string Type { get; }

        /// <inheritdoc />
        public PropertyDescription(JProperty sourceToken)
        {
            Name = sourceToken.Name;
            Type = ResolveType(sourceToken);
        }

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
    }
}