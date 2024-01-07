using AutoMapper;
using ChikovMF.Application.ChikovMF.Commands.CreateProject;
using ChikovMF.Application.ChikovMF.Commands.DeleteProject;
using ChikovMF.Application.ChikovMF.Queries.GetProjectDetails;
using ChikovMF.Application.ChikovMF.Queries.GetProjectList;
using ChikovMF.Application.Common.Exceptions;
using ChikovMF.MVC.Models.Dto;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("[action]")]
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

        [HttpPost("[action]/{projectId}")]
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

        private readonly IMapper _mapper;

        public ProjectController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
