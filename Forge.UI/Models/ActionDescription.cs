using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Forge.UI.Models
{
    public class ActionDescription
    {
        public ActionDescription(JProperty jProperty)
        {
            Name = jProperty.Name;
            Actions.AddRange(jProperty.Value.Values<dynamic>());
        }

        public string Name { get; set; }

        public List<dynamic> Actions { get; set; } = new List<dynamic>();
    }
}