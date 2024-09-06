using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validation.Price
{
    public class PriceCreateValidator : AbstractValidator<PriceDTO>
    {
        private readonly AspProjContext _context;

        public PriceCreateValidator(AspProjContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.PriceValue)
                .GreaterThan(0).WithMessage("PriceValue must be greater than 0.");

            RuleFor(x => x.ModelColorId)
                .GreaterThan(0).WithMessage("ModelColorId must be greater than 0.");
        }
    }
}
