using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validation.Brand
{
    public class BrandUpdateValidator : AbstractValidator<BrandsDTO>
    {
        private AspProjContext _context;

        public BrandUpdateValidator(AspProjContext context)
        {

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                .NotEmpty().MinimumLength(2).WithMessage("Minimum 2 characters."); ;
        }
    }
}
