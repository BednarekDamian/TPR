using System.Collections.Generic;
using System.Linq;

namespace Zadanie3.MyProduct
{
   public class MyProductMethods
    {
        private List<MyProduct> products;

        public MyProductMethods(ProductionDataContext dataContext)
        {
            products = dataContext.Product.AsEnumerable().Select(product => new MyProduct(product)).ToList();
        }

        public List<MyProduct> GetProductsByName(string namePart)
        {
            List<MyProduct> result = (from product in products
                                      where product.Name.Contains(namePart)
                                      select product).ToList();
            return result;
        }

        public List<MyProduct> GetNProductsFromCategory(string categoryName, int n)
        {
            List<MyProduct> result = (from product in products
                                      where product.SCategory != null && product.SCategory.ProductCategory.Name
                                          .Equals(categoryName)
                                      orderby product.Name, product.SCategory.ProductCategory.Name
                                      select product).Take(n).ToList();
            return result;
        }

        public List<MyProduct> GetNRecentlyModifiedProducts(int howManyProducts)
        {
            List<MyProduct> result = (from product in products
                                      orderby product.SellStartDate descending
                                      select product).Take(howManyProducts).ToList();
            return result;
        }
    }
}
