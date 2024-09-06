using Application.UseCases.Commands.Model;

using Application.UseCases.DTO;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validation.Model;

using System;

namespace Implementation.UseCases.Commands.ModelColor
{
    public class EfCreateModelColorCommand : EfUseCase, ICreateModelColorCommand
    {
        private ModelColorCreateValidator _validator;

        public EfCreateModelColorCommand(AspProjContext context, ModelColorCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 14;
        public string Name => "Create ModelColor";
        public string Description => "Create ModelColor command";

        public void Execute(ModelColorDTO request)
        {
            _validator.ValidateAndThrow(request);
            var modelColor = new Domain.ModelColor
            {
                ModelId = request.ModelId,
                ColorId = request.ColorId
            };

            Context.ModelColors.Add(modelColor);
            Context.SaveChanges();
        }
    }
}
