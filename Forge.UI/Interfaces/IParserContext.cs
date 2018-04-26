using System;

namespace Forge.UI.Interfaces
{
    public interface IParserContext
    {
        IModelDescription ModelDescription { get; }
        IActionCollection PossibleActions { get; }
    }
}