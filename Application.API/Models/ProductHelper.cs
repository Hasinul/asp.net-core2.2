using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.API.Models
{
    public static class ProductHelper
    {
        private static List<Product> Products = new List<Product>()
        {
            new Product()
            {
                Id=1,
                Name="Java how to program",
                Description ="It's a good book"
            },
            new Product()
            {
                Id=2,
                Name="C# best book",
                Description ="It's a good book"
            }
        };
        public static Product AddProduct(Product product)
        {
            product.Id = Products.Count + 1;
            Products.Add(product);
            return product;
        }
        public static Product GetAProduct(int id)
        {
            return Products.SingleOrDefault(x => x.Id == id);
        }
        public static List<Product> Get()
        {
            return Products;
        }
        public static Product Update(int id,Product product)
        {
            var findProduct = Products.SingleOrDefault(x => x.Id == id);
            //if (product == null) return HttpNotFound();
            findProduct.Name = product.Name;
            findProduct.Description = product.Description;
            return findProduct;
        }
        public static Product DeleteProduct(int id)
        {
            var product = Products.SingleOrDefault(x => x.Id == id);
            var products = Products.Where(x => x.Id == id).ToList();
            Products = products;
            return product;
        }
    }
}
