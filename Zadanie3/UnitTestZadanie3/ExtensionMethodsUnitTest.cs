using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Zadanie3;

namespace UnitTestZadanie3
{
    [TestClass]
    public class ExtensionMethodsUnitTest
    {

        #region Methods

        [TestMethod]
        public void GetProductsWithoutCategory_Method_Test()
        {
            using (ProductionDataContext testDataContext = new ProductionDataContext())
            {
                List<Product> products = testDataContext.GetTable<Product>().ToList();
                List<Product> productsWOTTest = products.GetProductsWithoutCategory_Method();

                Assert.AreEqual(209, productsWOTTest.Count);
                foreach (Product product in productsWOTTest)
                {
                    Assert.IsNull(product.ProductSubcategory);
                }
            }
        }
        [TestMethod]
        public void SplitIntoPage_Method_Test()
        {
            using (ProductionDataContext testDataContext = new ProductionDataContext())
            {
                List<Product> products = testDataContext.GetTable<Product>().ToList();
                List<Product> splited = products.SplitIntoPage_Method(20,0);

                Assert.AreEqual(20, splited.Count);
                for(int i = 0; i<20;i++)
                {
                    Assert.Equals(splited[i], products[i]);
                }
            }
        }
        [TestMethod]
        public void GetProductNamesWithVendorName_Method_Test()
        {
            using (ProductionDataContext testDataContext = new ProductionDataContext())
            {
                List<Product> products = testDataContext.GetTable<Product>().ToList();
                List<ProductVendor> productWVendorN = testDataContext.GetTable<ProductVendor>().ToList();

                string description = products.GetProductNamesWithVendorName_Method(productWVendorN);
                string[] rows = description.Split(Environment.NewLine.ToCharArray());

                Assert.IsTrue(rows.Contains(""));
                Assert.IsTrue(rows.Contains(""));
            }
        }

        #endregion
        #region Query
        [TestMethod]
        public void GetProductsWithoutCategory_Query_Test()
        {
            using (ProductionDataContext testDataContext = new ProductionDataContext())
            {
                List<Product> products = testDataContext.GetTable<Product>().ToList();
                List<Product> productsWOTTest = products.GetProductsWithoutCategory_Method();

                Assert.AreEqual(209, productsWOTTest.Count);
                foreach (Product product in productsWOTTest)
                {
                    Assert.IsNull(product.ProductSubcategory);
                }
            }
        }
        [TestMethod]
        public void SplitIntoPage_Query_Test()
        {
            using (ProductionDataContext testDataContext = new ProductionDataContext())
            {
                List<Product> products = testDataContext.GetTable<Product>().ToList();
                List<Product> splited = products.SplitIntoPage_Method(20, 0);

                Assert.AreEqual(20, splited.Count);
                for (int i = 0; i < 20; i++)
                {
                    Assert.Equals(splited[i], products[i]);
                }
            }
        }
        [TestMethod]
        public void GetProductNamesWithVendorName_Query_Test()
        {
            using (ProductionDataContext testDataContext = new ProductionDataContext())
            {
                List<Product> products = testDataContext.GetTable<Product>().ToList();
                List<ProductVendor> productWVendorN = testDataContext.GetTable<ProductVendor>().ToList();

                string description = products.GetProductNamesWithVendorName_Query();
                string[] rows = description.Split(Environment.NewLine.ToCharArray());

                Assert.IsTrue(rows.Contains("Internal Lock Washer 2-Pro Sport Industries"));
                Assert.IsTrue(rows.Contains("Paint - Black-Carlson Specialties"));
            }
        }

        #endregion
    }
}