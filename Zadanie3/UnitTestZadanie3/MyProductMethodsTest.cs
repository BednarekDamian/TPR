using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Zadanie3;
using Zadanie3.MyProduct;

namespace UnitTestZadanie3
{
    [TestClass]
    public class MyProductMethodsTest
    {
       // private static ProductionDataContext context = new ProductionDataContext();
        //private MyProductMethods MyProducts = new MyProductMethods(context);
        [TestMethod]
        public void GetProductsByName_Test()
        {

            using (ProductionDataContext context = new ProductionDataContext())
            {
                MyProductMethods MyProducts = new MyProductMethods(context);
                List<MyProduct> products1 = MyProducts.GetProductsByName("External");
                List<MyProduct> products2 = MyProducts.GetProductsByName("nonexistent_product");
                
                Assert.AreEqual(9, products1.Count);
                Assert.AreEqual(0, products2.Count);

                foreach (MyProduct product in products1)
                {
                    Assert.IsTrue(product.Name.Contains("External"));
                }
            }
                
            
        }

        [TestMethod]
        public void GetNProductsFromCategory_Test()
        {
            using (ProductionDataContext context = new ProductionDataContext())
            {
                MyProductMethods MyProducts = new MyProductMethods(context);

                List<MyProduct> products1 = MyProducts.GetNProductsFromCategory("Clothing", 3);

                Assert.AreEqual(3, products1.Count);

                foreach (MyProduct product in products1)
                {
                    Assert.IsTrue(product.SCategory.ProductCategory.Name.Equals("Clothing"));
                }
            }
        }

        [TestMethod]
        public void GetNRecentlyModifiedProducts_Test()
        {
            using (ProductionDataContext context = new ProductionDataContext())
            {
                MyProductMethods MyProducts = new MyProductMethods(context);

                List<MyProduct> products1 = MyProducts.GetNRecentlyModifiedProducts(10);
                MyProduct nextProduct = MyProducts.GetNRecentlyModifiedProducts(11)[10];

                Assert.AreEqual(10, products1.Count);

                foreach (MyProduct product in products1)
                {
                    Assert.IsTrue(product.SellStartDate.CompareTo(nextProduct.SellStartDate) == 0 ||
                                  product.SellStartDate.CompareTo(nextProduct.SellStartDate) == 1);
                }
            }
        }
        
    }
}
