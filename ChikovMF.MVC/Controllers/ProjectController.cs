using AutoMapper;
using ChikovMF.Application.ChikovMF.Commands.CreateProject;
using ChikovMF.Application.ChikovMF.Commands.DeleteProject;
using ChikovMF.Application.ChikovMF.Commands.UpdateProject;
using ChikovMF.Application.ChikovMF.Queries.GetProjectDetails;
using ChikovMF.Application.ChikovMF.Queries.GetProjectList;
using ChikovMF.Application.ChikovMF.Queries.GetProjectUpdate;
using ChikovMF.Application.Common.Exceptions;
using ChikovMF.Domain;
using ChikovMF.MVC.Models.Dto.Project.CreateProject;
using ChikovMF.MVC.Models.Dto.Project.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace ChikovMF.MVC.Controllers
{
    [Route("[controller]")]
    public class ProjectController : BaseController
    {
        [Route("/Projects")]
        public async Task<IActionResult> Index()
        {
            var query = new GetProjectListQuery { };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [Route("{projectId}")]
        public async Task<IActionResult> View(int projectId)
        {
            var query = new GetProjectDetailsQuery
            {
                ProjectId = projectId,
            };

            ProjectDetailsViewModel vm;

            try
            {
                vm = await Mediator.Send(query);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return View(vm);
        }

        [HttpGet("Create"), Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create"), Authorize]
        public async Task<IActionResult> Create(CreateProjectDto createProjectDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreateProjectCommand>(createProjectDto);

                var projectId = await Mediator.Send(command);

                return RedirectToAction("View", new { projectId = projectId });
            }

            return View();
        }

        [HttpPost("Delete/{projectId}"), Authorize]
        public async Task<IActionResult> Delete(int projectId)
        {
            if (ModelState.IsValid)
            {
                var command = new DeleteProjectCommand
                {
                    ProjectId = projectId,
                };

                await Mediator.Send(command);

                return RedirectToAction("Index");
            }

            return RedirectToAction("View", new { projectId = projectId });
        }

        [HttpGet("Update/{projectId}"), Authorize]
        public async Task<IActionResult> Update(int projectId)
        {
            var query = new GetProjectUpdateQuery
            {
                ProjectId = projectId,
            };

            ProjectUpdateViewModel vm;

            try
            {
                vm = await Mediator.Send(query);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            var dto = _mapper.Map<UpdateProjectDto>(vm);

            return View(dto);
        }

        [HttpPost("Update"), Authorize]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto updateProjectDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<UpdateProjectCommand>(updateProjectDto);

                var projectId = await Mediator.Send(command);

                return RedirectToAction("View", new { projectId = projectId });
            }
            
            return View("Update", updateProjectDto);
        }

        private readonly IMapper _mapper;

        public ProjectController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
