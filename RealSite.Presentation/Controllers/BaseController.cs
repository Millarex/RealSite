using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace RealSite.Presentation.Controllers
{
    public abstract class BaseController : Controller
    {
        //For request
        private IMediator _mediator;
        //if _mediator == null get it
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
