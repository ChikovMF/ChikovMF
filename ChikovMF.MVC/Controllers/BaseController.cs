using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChikovMF.MVC.Controllers
{
    [Controller]
    public abstract class BaseController : Controller
    {
        private IMediator _mediator = null!;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>()
                ?? throw new NullReferenceException("Mediator service not found.");
    }
}
