using System.Collections.Generic;

namespace Forge.UI.Interfaces
{
    public interface IModelDescription
    {
        string Name { get; set; }
        IEnumerable<IDescription> Properties { get; set; }
        IEnumerable<IDescription> Actions { get; set; }
        IEnumerable<IDescription> Triggers { get; set; }
    }
}