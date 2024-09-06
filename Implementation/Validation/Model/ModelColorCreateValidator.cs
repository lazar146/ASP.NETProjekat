using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validation.Model
{
    public class ModelColorCreateValidator : AbstractValidator<ModelColorDTO>
    {
        private readonly AspProjContext _context;

        public ModelColorCreateValidator(AspProjContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.ModelId)
                .GreaterThan(0).WithMessage("ModelId must be greater than 0.");

            RuleFor(x => x.ColorId)
                .GreaterThan(0).WithMessage("ColorId must be greater than 0.");
        }
    }
}
