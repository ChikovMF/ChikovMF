using ChikovMF.Application.ChikovMF.Queries.GetProjectDetails;
using ChikovMF.Application.ChikovMF.Queries.GetProjectList;
using Microsoft.AspNetCore.Mvc;

namespace ChikovMF.MVC.Controllers
{
    public class ProjectController : BaseController
    {
        [Route("Projects")]
        public async Task<IActionResult> Index()
        {
            var query = new GetProjectListQuery { };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [Route("Project/{projectId}")]
        public async Task<IActionResult> View(int projectId)
        {
            var query = new GetProjectDetailsQuery
            {
                ProjectId = projectId,
            };
            var vm = await Mediator.Send(query);

            return View(vm);
        }
    }
}
