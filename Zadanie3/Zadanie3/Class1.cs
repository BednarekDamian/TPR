using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie3;

namespace Task3
{
    public static class Methods
    {
        private static ProductionDataContext context = new ProductionDataContext();

        public static List<Product> GetProductsByName(string namePart)
        {
            List<Product> products = context.Product
                .Where(product => product.Name.Contains(namePart))
                .ToList();

            return products;
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            List<Product> products = context.ProductVendor
                .Where(productVendor => productVendor.Vendor.Name.Equals(vendorName))
                .Select(productVendor => productVendor.Product)
                .ToList();

            return products;
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            List<string> productNames = context.ProductVendor
                .Where(productVendor => productVendor.Vendor.Name.Equals(vendorName))
                .Select(productVendor => productVendor.Product.Name)
                .ToList();

            return productNames;
        }

        public static string GetProductVendorByProductName(string productName)
        {
            string vendor = context.ProductVendor
                .Where(productVendor => productVendor.Product.Name.Equals(productName))
                .Select(productVendor => productVendor.Vendor.Name)
                .FirstOrDefault();

            return vendor;
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            List<Product> products = context.ProductReview
                .OrderBy(productReview => productReview.ReviewDate)
                .Select(productReview => productReview.Product)
                .Take(howManyReviews)
                .Distinct()
                .ToList();

            return products;
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            List<Product> products = context.ProductReview
                .OrderBy(productReview => productReview.ReviewDate)
                .Select(productReview => productReview.Product)
                .Take(howManyProducts)
                .ToList();

            return products;
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            List<Product> products = context.Product
                .Where(product => product.ProductSubcategory.ProductCategory.Name.Equals(categoryName))
                .OrderBy(product => product.Name)
                .Take(n)
                .ToList();

            return products;
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            decimal costs = context.Product
                .Where(product => product.ProductSubcategory.ProductCategory.ProductCategoryID == category.ProductCategoryID)
                .Select(product => product.StandardCost)
                .Sum();

            return Decimal.ToInt32(costs);
        }

        public static ProductCategory GetProductCategoryByName(string name)
        {
            ProductCategory category = context.ProductCategory
                .Where(productCategory => productCategory.Name.Equals(name))
                .FirstOrDefault();

            return category;
        }
    }
}