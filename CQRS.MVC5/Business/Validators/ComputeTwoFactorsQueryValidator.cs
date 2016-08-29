using CQRS.MVC5.Business.Query;
using FluentValidation;

namespace CQRS.MVC5.Business.Validators
{
    public class ComputeTwoFactorsQueryValidator : AbstractValidator<ComputeTwoFactorsQuery>
    {
        public ComputeTwoFactorsQueryValidator()
        {
            RuleFor(q => q.Factor1).Must(f => f > 0).WithMessage("Le premier facteur doit être supérieur à 0");
            RuleFor(q => q.Factor2).Must(f => f > 0).WithMessage("Le second facteur doit être supérieur à 0");
        }
    }
}