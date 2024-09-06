using Application.UseCases.Commands.Brands;
using Application.UseCases.Commands.Color;
using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using Implementation.Validation.Brand;
using Implementation.Validation.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Color
{
    public class EfCreateColorCommand : EfUseCase, ICreateColorCommand
    {
        private ColorCreateValidator _validator;
        public EfCreateColorCommand(AspProjContext context, ColorCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Create Color";

        public string Description => "Create color command";

        
        public void Execute(ColorDTO request)
        {
            _validator.ValidateAndThrow(request);
            var color = new Domain.Color
            {
                Name = request.Name,
            };
            Context.Colors.Add(color);  
            Context.SaveChanges();
        }
    }
}
