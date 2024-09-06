using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validation.Color
{
    public class ColorCreateValidator : AbstractValidator<ColorDTO>
    {
        private AspProjContext _context;

        public ColorCreateValidator(AspProjContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
          .NotEmpty().WithMessage("Name is required.")
          .MinimumLength(2).WithMessage("Name must be at least 2 characters long.");
        }
    }
}
