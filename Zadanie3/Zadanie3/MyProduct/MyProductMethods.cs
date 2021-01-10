using System.Collections.Generic;
using System.Linq;

namespace Zadanie3
{
    class MyProductMethods
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
                                      where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name
                                          .Equals(categoryName)
                                      orderby product.Name, product.ProductSubcategory.ProductCategory.Name
                                      select product).Take(n).ToList();
            return result;
        }

        public List<MyProduct> GetNRecentlyModifiedProducts(int howManyProducts)
        {
            List<MyProduct> result = (from product in products
                                      orderby product.ModifiedDate descending
                                      select product).Take(howManyProducts).ToList();
            return result;
        }
    }
}
