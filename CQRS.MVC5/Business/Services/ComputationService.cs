namespace CQRS.MVC5.Business.Services
{
    public class ComputationService : IComputationService
    {
        public double Compute(double a, double b)
        {
            return a * b;
        }
    }
}