using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NORISarchitect.API.Data;
using NORISarchitect.API.Projects.DTOs;
using NORISarchitect.API.Projects.Models;
using NORISarchitect.API.Projects.Repositories;
using NORISarchitect.API.UnitOfWork;

namespace NORISarchitect.API.Projects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProjectsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await unitOfWork.Projects.GetAll();
            var projectsDto = mapper.Map<List<ProjectDto>>(projects);
            return Ok(projectsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var existingProject = await unitOfWork.Projects.GetById(id);
            if (existingProject == null)
            {
                return NotFound();
            }
            return Ok(existingProject);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectDto addProjectDto)
        {
            var project = mapper.Map<Project>(addProjectDto);
            await unitOfWork.Projects.Create(project);
            var projectDto = mapper.Map<ProjectDto>(project);
            return CreatedAtAction(nameof(GetById), new { projectDto.Id }, projectDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProjectDto updateProjectDto)
        {

            var existingProject = mapper.Map<Project>(updateProjectDto);
            if (existingProject == null)
            {
                return NotFound();
            }
            var project = await unitOfWork.Projects.Update(id,existingProject);           
            var projectDto = mapper.Map<ProjectDto>(existingProject);
            return Ok(projectDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            var existingProject = await unitOfWork.Projects.Remove(id);
            if (existingProject == null)
            {
                return NotFound(id);
            }            
            var removedProject = mapper.Map<ProjectDto>(existingProject);
            return Ok(removedProject);
        }
    }
}
