using System;
using Forge.UI.Interfaces;

namespace Forge.UI.Actions
{
    public class SetAction : IAction
    {
        public string Key { get; } = "set";
        public Action<object[]> Action { get; } = DoAction;

        private static void DoAction(object[] obj)
        {
            
        }
    }
}