using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public static class ExtMethods
    {
        private static ProductionDataContext context = new ProductionDataContext();
       
        public static List<Product> GetProductsWithoutCategoryQuery(this List<Product> products)
        {
            IEnumerable<Product> productsWithoutC = from product in products
                                                    where product.ProductSubcategory == null
                                                    select product;
            return productsWithoutC.ToList();
        }


    }
}

        

