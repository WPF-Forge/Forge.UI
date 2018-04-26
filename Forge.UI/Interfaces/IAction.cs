using System;

namespace Forge.UI.Interfaces
{
    public interface IAction
    {
        string Key { get; }
        Action<object[]> Action { get; }
    }
}