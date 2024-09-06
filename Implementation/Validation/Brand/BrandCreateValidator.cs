using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;

namespace Implementation.Validation.Brand
{
    public class BrandCreateValidator : AbstractValidator<BrandsDTO>
    {
        private AspProjContext _context;

        public BrandCreateValidator(AspProjContext context)
        {

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                .NotEmpty().MinimumLength(2).WithMessage("Minimum 2 characters."); ;
        }
    }
}
