using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class ProductCartDTO : BaseDTO
    {
        public int Quantity { get; set; }
        public int ModelColorId { get; set; }
        public int CartId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
