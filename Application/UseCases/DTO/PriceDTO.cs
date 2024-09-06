using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class PriceDTO : BaseDTO
    {
        public decimal PriceValue { get; set; }
        public int ModelColorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
