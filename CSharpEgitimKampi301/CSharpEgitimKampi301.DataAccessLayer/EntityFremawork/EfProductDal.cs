using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Context;
using CSharpEgitimKampi301.DataAccessLayer.Repositories;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.EntityFremawork
{
    public class EfProductDal : GenericRepositories<Product>, IProductDal
    {
        public List<object> GetProductsWithCategory()
        {
            using (var context = new CampContext())
            {
                var values = context.Products.Select(p => new
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductStock = p.ProductStock,
                    ProductPrice = p.ProductPrice,
                    ProductDescription = p.ProductDescription,
                    CategoryName = p.Category.CategoryName,

                }).ToList();

                return values.Cast<object>().ToList();
            }
        }
    }
}
