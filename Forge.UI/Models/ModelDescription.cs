using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Forge.UI.Models
{
    public class ModelDescription
    {
        public string Name { get; }
        public JObject Properties { get; set; }
        public JObject Actions { get; set; }
        public JObject Triggers { get; set; }
    }
}
