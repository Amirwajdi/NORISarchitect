using System.ComponentModel.DataAnnotations;

namespace NORISarchitect.API.Projects.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Client { get; set; }
        [Required]
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
