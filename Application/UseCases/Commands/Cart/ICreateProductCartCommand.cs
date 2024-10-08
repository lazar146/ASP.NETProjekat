﻿using Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Cart
{
    public interface ICreateProductCartCommand : ICommand<ProductCartDTO>
    {
    }
}
