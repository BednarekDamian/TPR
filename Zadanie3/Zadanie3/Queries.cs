using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie3
{
    public class Queries
    {
        private static ProductionDataContext context = new ProductionDataContext();


        public static List<Product> GetProductsByName_Query(string namePart)
        {
            IEnumerable<Product> products = from product in context.Product
                                            where product.Name.Contains(namePart)
                                            select product;

            return new List<Product>(products.ToArray());
        }
        public static List<Product> GetProductsByName_Method(string namePart)
        {
            List<Product> products = context.Product.Where(product => product.Name.Contains(namePart)).ToList();
            return products;
        }

        public static List<Product> GetProductsByVendorName_Query(string vendorName)
        {
            IEnumerable<Product> products = from productVendor in context.ProductVendor
                                            where productVendor.Vendor.Name.Equals(vendorName)
                                            select productVendor.Product;

            return new List<Product>(products.ToArray());
        }
        public static List<Product> GetProductsByVendorName_Method(string vendorName)
        {
            List<Product> products = context.ProductVendor
                .Where(productVendor => productVendor.Vendor.Name.Equals(vendorName))
                .Select(productVendor => productVendor.Product)
                .ToList();

            return products;
        }
        public static List<string> GetProductNamesByVendorName_Query(string vendorName)
        {
            IEnumerable<string> productNames = from productVendor in context.ProductVendor
                                               where productVendor.Vendor.Name.Equals(vendorName)
                                               select productVendor.Product.Name;

            return new List<string>(productNames.ToArray());
        }
        public static List<string> GetProductNamesByVendorName_Method(string vendorName)
        {
            List<string> productNames = context.ProductVendor
                .Where(productVendor => productVendor.Vendor.Name.Equals(vendorName))
                .Select(productVendor => productVendor.Product.Name)
                .ToList();

            return productNames;
        }
        public static string GetProductVendorByProductName_Query(string productName)
        {
            IEnumerable<string> vendor = from productVendor in context.ProductVendor
                                         where productVendor.Product.Name.Equals(productName)
                                         select productVendor.Vendor.Name;

            return vendor.First();
        }
        public static string GetProductVendorByProductName_Method(string productName)
        {
            string vendor = context.ProductVendor
                .Where(productVendor => productVendor.Product.Name.Equals(productName))
                .Select(productVendor => productVendor.Vendor.Name)
                .FirstOrDefault();

            return vendor;
        }
        public static List<Product> GetProductsWithNRecentReviews_Query(int howManyReviews)
        {
            IEnumerable<Product> products = from productReview in context.ProductReview
                                            orderby productReview.ReviewDate
                                            select productReview.Product;

            return new List<Product>(products.Take(howManyReviews).Distinct().ToArray());
        }
        public static List<Product> GetProductsWithNRecentReviews_Method(int howManyReviews)
        {
            List<Product> products = context.ProductReview
                .OrderBy(productReview => productReview.ReviewDate)
                .Select(productReview => productReview.Product)
                .Take(howManyReviews)
                .Distinct()
                .ToList();

            return products;
        }
        public static List<Product> GetNRecentlyReviewedProducts_Query(int howManyProducts)
        {
            IEnumerable<Product> products = from productReview in context.ProductReview
                                            orderby productReview.ReviewDate 
                                            select productReview.Product;

            return new List<Product>(products.ToArray().Take(howManyProducts));
        }
        public static List<Product> GetNRecentlyReviewedProducts_Method(int howManyProducts)
        {
            List<Product> products = context.ProductReview
                .OrderBy(productReview => productReview.ReviewDate)
                .Select(productReview => productReview.Product)
                .Take(howManyProducts)
                .ToList();

            return products;
        }

        public static List<Product> GetNProductsFromCategory_Query(string categoryName, int n)
        {
            IEnumerable<Product> products = from product in context.Product
                                            where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                            orderby product.Name
                                            select product;

            return products.Take(n).ToList();
        }
        public static List<Product> GetNProductsFromCategory_Method(string categoryName, int n)
        {
            List<Product> products = context.Product
                .Where(product => product.ProductSubcategory.ProductCategory.Name.Equals(categoryName))
                .OrderBy(product => product.Name)
                .Take(n)
                .ToList();

            return products;
        }
        public static int GetTotalStandardCostByCategory_Query(ProductCategory category)
        {
            IEnumerable<decimal> costs = from product in context.Product
                                         where product.ProductSubcategory.ProductCategory.ProductCategoryID == category.ProductCategoryID
                                         select product.StandardCost;

            return Decimal.ToInt32(costs.Sum());
        }
        public static int GetTotalStandardCostByCategory_Method(ProductCategory category)
        {
            decimal costs = context.Product
                .Where(product => product.ProductSubcategory.ProductCategory.ProductCategoryID == category.ProductCategoryID)
                .Select(product => product.StandardCost)
                .Sum();

            return Decimal.ToInt32(costs);
        }
        public static ProductCategory GetProductCategoryByName_Query(string name)
        {
            IEnumerable<ProductCategory> categories = from category in context.ProductCategory
                                                      where category.Name.Equals(name)
                                                      select category;
            return categories.First();
        }
        public static ProductCategory GetProductCategoryByName_Method(string name)
        {
            ProductCategory category = context.ProductCategory
                .Where(productCategory => productCategory.Name.Equals(name))
                .FirstOrDefault();

            return category;
        }
    }
}
