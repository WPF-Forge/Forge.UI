using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Forge.UI.Models
{
    public class ModelDescription
    {
        public string Name { get; }

        public List<PropertyDescription> Properties { get; set; } = new List<PropertyDescription>();

        public List<ActionDescription> Actions { get; set; } = new List<ActionDescription>();

        public JObject Triggers { get; set; }
    }
}