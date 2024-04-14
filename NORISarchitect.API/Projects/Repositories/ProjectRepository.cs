using Microsoft.EntityFrameworkCore;
using NORISarchitect.API.Data;
using NORISarchitect.API.Projects.Models;

namespace NORISarchitect.API.Projects.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly NORISDbContext dbContext;

        public ProjectRepository(NORISDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Project> Create(Project project)
        {
            await dbContext.Projects.AddAsync(project);
            await dbContext.SaveChangesAsync();
            return project;
        }

        public async Task<List<Project>> GetAll()
        {
            return await dbContext.Projects.ToListAsync();
        }

        public async Task<Project?> GetById(int id)
        {
            var existingProject = await dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProject == null)
            {
                return null;
            }
            return existingProject;
        }

        public async Task<Project?> Remove(int id)
        {
            var existingProject = await dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProject == null)
            {
                return null;
            }
            dbContext.Projects.Remove(existingProject);
            await dbContext.SaveChangesAsync();
            return existingProject;
        }

        public async Task<Project?> Update(int id, Project project)
        {
            var existingProject = await dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProject == null)
            {
                return null;
            }
            existingProject.Name = project.Name;
            existingProject.Client = project.Client;
            existingProject.Description = project.Description;
            existingProject.ImageUrl = project.ImageUrl;
            await dbContext.SaveChangesAsync();
            return existingProject;
        }
    }
}
