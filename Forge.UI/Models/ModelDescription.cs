using System.Collections.Generic;
using Forge.UI.Interfaces;
using Newtonsoft.Json.Linq;

namespace Forge.UI.Models
{
    public class ModelDescription : IModelDescription
    {
        public string Name { get; set; }

        public IEnumerable<IDescription> Properties { get; set; }

        public IEnumerable<IDescription> Actions { get; set; }

        public IEnumerable<IDescription> Triggers { get; set; }
    }
}