using MediatR;

namespace CQRS.MVC5.Business.Query
{
    public class WelcomeMessageQuery : IRequest<string>
    {
        public string UserName { get; set; }

        public WelcomeMessageQuery(string userName)
        {
            UserName = userName;
        }
    }
}