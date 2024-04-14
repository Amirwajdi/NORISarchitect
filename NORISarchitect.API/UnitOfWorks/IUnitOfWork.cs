using NORISarchitect.API.Data;
using NORISarchitect.API.Projects.Repositories;

namespace NORISarchitect.API.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProjectRepository Projects { get; }
    }
}
