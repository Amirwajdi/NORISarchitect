using NORISarchitect.API.Projects.Models;

namespace NORISarchitect.API.Projects.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
        Task<Project?> GetById(int id);
        Task<Project> Create(Project project);
        Task<Project?> Update(int id, Project project);
        Task<Project?> Remove(int id);
    }
}
