using ChikovMF.Application.ChikovMF.Queries.GetProjectList;
using Microsoft.AspNetCore.Mvc;

namespace ChikovMF.MVC.Controllers
{
    public class ProjectController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var query = new GetProjectListQuery { };
            var vm = await Mediator.Send(query);
            return View(vm);
        }
    }
}
