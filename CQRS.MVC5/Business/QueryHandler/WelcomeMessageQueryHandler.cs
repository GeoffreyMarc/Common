using CQRS.MVC5.Business.Query;
using MediatR;

namespace CQRS.MVC5.Business.QueryHandler
{
    public class WelcomeMessageQueryHandler : IRequestHandler<WelcomeMessageQuery, string>
    {
        public string Handle(WelcomeMessageQuery message)
        {
            return $"Bienvenue {(string.IsNullOrEmpty(message.UserName) ? "visiteur anonyme" : message.UserName)}";
        }
    }
}