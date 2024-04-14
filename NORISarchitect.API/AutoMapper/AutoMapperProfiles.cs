using AutoMapper;
using NORISarchitect.API.Projects.DTOs;
using NORISarchitect.API.Projects.Models;

namespace NORISarchitect.API.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
        }
    }
}
