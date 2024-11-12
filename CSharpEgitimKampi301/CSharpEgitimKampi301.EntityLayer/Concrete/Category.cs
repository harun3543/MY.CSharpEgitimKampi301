using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }

        // ********* ilişkiler ***********
        // tek bir category'de birden fazla product olabileceği için 
        // product listesi tanımladık.
        public List<Product> Products{ get; set; }

    }
}
