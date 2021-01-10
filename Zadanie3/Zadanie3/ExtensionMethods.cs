using System;
using System.Collections.Generic;
using System.Linq;

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

      

        public static string GetProductNamesWithVendorName_Query(this List<Product> products)
        {
            var productWithVendor = from product in products
                                    from productVendor in context.ProductVendor
                                    where productVendor.ProductID == product.ProductID
                                    select new { ProductName = productVendor.Product.Name, VendorName = productVendor.Vendor.Name };

            IEnumerable<string> lines = productWithVendor.Select(p => p.ProductName + " - " + p.VendorName);

            return String.Join("\n", lines.ToArray());
        }

        public static string GetProductNamesWithVendorName_Method(this List<Product> products, List<ProductVendor> productWVendorN)
        {
            var productWithVendor = products.Join(
                context.ProductVendor,
                product => product.ProductID,
                productVendor => productVendor.ProductID,
                (product, productVendor) => new { ProductName = product.Name, VendorName = productVendor.Vendor.Name });

            IEnumerable<string> lines = productWithVendor.Select(p => p.ProductName + " - " + p.VendorName);

            return String.Join("\n", lines.ToArray());
        }
    }
}

