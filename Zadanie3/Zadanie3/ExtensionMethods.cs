using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zadanie3
{
    public static class ExtensionMethods
    {
        private static ProductionDataContext context = new ProductionDataContext();

        public static List<Product> GetProductsWithoutCategory_Query(this List<Product> products)
        {
            IEnumerable<Product> productsWithoutCategory = from product in products
                                                           where product.ProductSubcategory == null
                                                           select product;

            return productsWithoutCategory.ToList();
        }

        public static List<Product> GetProductsWithoutCategory_Method(this List<Product> products)
        {
            IEnumerable<Product> productsWithoutCategoty = products.Where(product => product.ProductSubcategory == null);

            return productsWithoutCategoty.ToList();
        }
        public static List<Product> SplitIntoPage_Query(this List<Product> products, int size, int page)
        {
            List<Product> result = (from product in products
                                    select product).Skip(size * (page - 1)).Take(size).ToList();
            return result;
        }
        public static List<Product> SplitIntoPage_Method(this List<Product> products, int size, int page)
        {
            return products.Skip(size * (page - 1)).Take(size).ToList();
        }

      

        public static string GetProductNamesWithVendorName_Query(this List<Product> products, List<ProductVendor> productWVendorN)
        {
            var productWithVendor = (from product in products
                                    from vendor in productWVendorN
                                    where vendor.ProductID == product.ProductID
                                    select (product.Name, vendor.Vendor.Name)).ToList();

            StringBuilder names = new StringBuilder();
            for (int i = 0; i < productWithVendor.Count; i++)
            {
                names.Append(string.Join("-", productWithVendor[i].Item1, productWithVendor[i].Item2));
                if (i != productWithVendor.Count - 1)
                    names.Append(Environment.NewLine);
            }
            return names.ToString();
        }

        public static string GetProductNamesWithVendorName_Method(this List<Product> products, List<ProductVendor> productWVendorN)
        {
            var productWithVendor = products.Join(productWVendorN, product => product.ProductID, productVendor => productVendor.ProductID,
                (product, productVendor) => new { ProductName = product.Name, VendorName = productVendor.Vendor.Name }).ToList();

            StringBuilder names = new StringBuilder();
            for (int i = 0; i < productWithVendor.Count; i++)
            {
                names.Append(string.Join("-", productWithVendor[i].ProductName, productWithVendor[i].VendorName));
                if (i != productWithVendor.Count - 1)
                    names.Append(Environment.NewLine);
            }
            return names.ToString();
        }
    }
}

