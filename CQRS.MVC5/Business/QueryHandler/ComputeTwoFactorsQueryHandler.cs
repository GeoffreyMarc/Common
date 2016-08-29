using CQRS.MVC5.Business.Query;
using CQRS.MVC5.Business.Services;
using MediatR;

namespace CQRS.MVC5.Business.QueryHandler
{
    public class ComputeTwoFactorsQueryHandler : IRequestHandler<ComputeTwoFactorsQuery, double>
    {
        private IComputationService _computationService;

        public ComputeTwoFactorsQueryHandler(IComputationService computationService)
        {
            _computationService = computationService;
        }
        public double Handle(ComputeTwoFactorsQuery message)
        {
            return _computationService.Compute(message.Factor1, message.Factor2);
        }
    }
}