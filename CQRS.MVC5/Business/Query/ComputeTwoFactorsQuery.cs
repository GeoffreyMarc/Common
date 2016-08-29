using MediatR;

namespace CQRS.MVC5.Business.Query
{
    public class ComputeTwoFactorsQuery : IRequest<double>
    {
        public double Factor1 { get; private set; }
        public double Factor2 { get; private set; }

        public ComputeTwoFactorsQuery(double factor1, double factor2)
        {
            Factor1 = factor1;
            Factor2 = factor2;
        }
    }
}