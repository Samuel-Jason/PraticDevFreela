using DevFreela.API.Filters;
using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DevFreela.API.Controllers
{
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

        //api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        [TypeFilter(typeof(ValidationFilter))]
        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel InputModel)
        {
            _projectService.CreateComment(InputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, InputModel);
        }

        [HttpPost]
        [TypeFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        //api/projects/2
        [HttpPut("{id}")]
        [TypeFilter(typeof(ValidationFilter))]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel InputModel)
        {
            _projectService.Update(InputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, InputModel);
        }

        // api/projects?query=net core
        [HttpGet]
        [TypeFilter(typeof(ValidationFilter))]
        public IActionResult Get(string query)
        {
            var projetos = _projectService.GetAll(query);

            return Ok(projetos);
        }

        //api/projects/3 DELETE
        [HttpDelete("id")]
        [TypeFilter(typeof(ValidationFilter))]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return NoContent();
        }

        //api/projects/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var resource = _projectService.GetById(id);

            if (resource != null)
            {
                return Ok(resource);
            }

            return NotFound($"Projeto com ID {id} não encontrado.");
        }

        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel loginModel)
        {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);

            return NoContent();
        }
    }
}
