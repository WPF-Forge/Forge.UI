using Newtonsoft.Json.Linq;

namespace Forge.UI.Interfaces
{
    public interface IDescription
    {
        void FromProperty(JProperty property);
    }
}