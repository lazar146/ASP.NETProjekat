using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cart : Entity
    {
        public int UserId { get; set; }
        
        public ICollection<ProductCart> ProductCart { get; set; }

        
        public User userCart { get; set; }
    }
}
