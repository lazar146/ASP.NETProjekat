using Application.UseCases.Commands.Brands;
using Application.UseCases.Commands.Image;
using Application.UseCases.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Image
{
    public class EfCreateImageCommand : EfUseCase, ICreateImageCommand
    {
        public EfCreateImageCommand(AspProjContext context) : base(context)
        {
        }

        public int Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public void Execute(ImageDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
