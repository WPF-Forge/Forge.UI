using System;
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
            Type = sourceToken.Value["type"].Value<string>();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Type)}: {Type}";
        }
    }
}
