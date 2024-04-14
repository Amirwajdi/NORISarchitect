using System.ComponentModel.DataAnnotations;

namespace NORISarchitect.API.Projects.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Client { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
