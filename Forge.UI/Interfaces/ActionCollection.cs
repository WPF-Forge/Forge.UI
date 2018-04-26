using System.Collections.Generic;
using System.Linq;

namespace Forge.UI.Interfaces
{
    internal class ActionCollection : Dictionary<string, List<IAction>>, IActionCollection
    {
        public void AddAction(IAction action)
        {
            AddOrSet(action.Key, action);
        }

        public void AddOrSet(string key, IAction value)
        {
            if (ContainsKey(key))
            {
                this[key].Add(value);
            }
            else
            {
                this[key] = new List<IAction> {value};
            }
        }

        public void AddOrSet(string key, IEnumerable<IAction> valueEnumerable)
        {
            foreach (var item in valueEnumerable)
            {
                AddOrSet(key, item);
            }
        }

        public void FromLookup(ILookup<string, IAction> lookup)
        {
            foreach (var grouping in lookup)
            {
                AddOrSet(grouping.Key, grouping);
            }
        }
    }
}