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


                Assert.AreEqual(209, productWVendorN.Count);
                foreach (Product product in productWVendorN)
                {
                    Assert.IsNull(product.ProductSubcategory);
                }
            }
        }

        #endregion
        #region Query
        [TestMethod]
        public void GetProductsWithoutCategory_Query()
        {
            using (ProductionDataContext testDataContext = new ProductionDataContext())
            {
                List<Product> products = testDataContext.GetTable<Product>().ToList();
                List<Product> productsWOTTest = products.();

                Assert.AreEqual(209, productsWOTTest.Count);
                foreach (Product product in productsWOTTest)
                {
                    Assert.IsNull(product.ProductSubcategory);
                }
            }
        }
        [TestMethod]
        public void SplitIntoPage_Query()
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
        public void GetProductNamesWithVendorName_Query()
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

        #endregion
    }
}