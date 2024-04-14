using NORISarchitect.API.Data;
using NORISarchitect.API.Projects.Repositories;
using NORISarchitect.API.UnitOfWork;

namespace NORISarchitect.API.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NORISDbContext db;
        public IProjectRepository Projects { get; private set; }

        public UnitOfWork(NORISDbContext db)
        {
            this.db = db;
            Projects = new ProjectRepository(db);
        }
        
    }
}
