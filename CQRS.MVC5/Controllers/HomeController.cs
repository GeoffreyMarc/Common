using CQRS.MVC5.Business.Query;
using MediatR;
using System.Web.Mvc;

namespace CQRS.MVC5.Controllers
{
    public class HomeController : Controller
    {
        public IMediator Mediator { get; private set; }

        public HomeController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = Mediator.Send(new WelcomeMessageQuery(User?.Identity?.Name));

            return View("Index");
        }

        [HttpPost]
        public ActionResult Compute(ComputeTwoFactorsQuery query)
        {
            var result = Mediator.Send(query);

            return View("Compute", result);
        }
    }
}