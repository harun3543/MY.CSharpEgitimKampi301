using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }

        //*************** ilişkiler *******************
        // Her product'ın bir category si olmak zorunda
        // Product tablosu category ile ilişkilendirdik.
        // her bir product sadece bir ccategory'e ait olduğu için tek bir category
        // tanımladık.
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        //
        public List<Order> Orders { get; set; }
    }
}
