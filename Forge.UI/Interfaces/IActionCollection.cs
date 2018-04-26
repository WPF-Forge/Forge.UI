using System.Collections.Generic;
using System.Linq;

namespace Forge.UI.Interfaces
{
    public interface IActionCollection : IDictionary<string, List<IAction>>
    {
        void AddAction(IAction action);
        void AddOrSet(string key, IAction value);
        void AddOrSet(string key, IEnumerable<IAction> valueEnumerable);
        void FromLookup(ILookup<string, IAction> lookup);
    }
}