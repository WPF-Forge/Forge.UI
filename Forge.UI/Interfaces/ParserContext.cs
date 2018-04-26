using System.Linq;

namespace Forge.UI.Interfaces
{
    internal class ParserContext : IParserContext
    {
        public ParserContext(IModelDescription modelDescription, ILookup<string, IAction> possibleActions)
        {
            ModelDescription = modelDescription;
            PossibleActions = new ActionCollection();
            PossibleActions.FromLookup(possibleActions);
        }

        public IModelDescription ModelDescription { get; }
        public IActionCollection PossibleActions { get; }
    }
}