using Website.Core.Common.Entities;

namespace Website.Core.Common.Interfaces
{
    public interface IPageComponent
    {
        string Key { get; }

        ComponentOutput GetOutput(long id);
    }
}