using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Zadanie3;

namespace UnitTestZadanie3
{
    [TestClass]
    public class QueriesTests
    {
        
        [TestMethod]
        public void GetProductsByName_Method_Test()
        {
            using (Queries database = new Queries())
            {
                List<Product> products1 = database.GetProductsByName_Method("external");
                List<Product> products2 = database.GetProductsByName_Method("nonexistent_product");
           
            Assert.AreEqual(9, products1.Count);
            Assert.AreEqual(0, products2.Count);

            foreach (Product product in products1)
            {
                Assert.IsTrue(product.Name.ToLower().Contains("external"));
            }
            }
        }

        [TestMethod]
        public void GetProductsByName_Query_Test()
        {
            using (Queries database = new Queries())
            {
                List<Product> products1 = database.GetProductsByName_Query("external");
                List<Product> products2 = database.GetProductsByName_Query("nonexistent_product");
      
            Assert.AreEqual(9, products1.Count);
            Assert.AreEqual(0, products2.Count);

            foreach (Product product in products1)
            {
                Assert.IsTrue(product.Name.ToLower().Contains("external"));
            }
            }
        }

        [TestMethod]
        public void GetProductsByVendorName_Method_Test()
        {
            using (Queries database = new Queries())
            {
                List<Product> products1 = database.GetProductsByVendorName_Method("aurora bike center");
                List<Product> products2 = database.GetProductsByVendorName_Method("nonexistent_vendor");
         
            Assert.AreEqual(19, products1.Count);
            Assert.AreEqual(0, products2.Count);
            }
        }

        [TestMethod]
        public void GetProductsByVendorName_Query_Test()
        {
            using (Queries database = new Queries())
            {
                List<Product> products1 = database.GetProductsByVendorName_Query("aurora bike center");
                List<Product> products2 = database.GetProductsByVendorName_Query("nonexistent_vendor");
           
            Assert.AreEqual(19, products1.Count);
            Assert.AreEqual(0, products2.Count);
            }
        }

        [TestMethod]
        public void GetProductNamesByVendorName_Method_Test()
        {
            using (Queries database = new Queries())
            {
                List<string> products1 = database.GetProductNamesByVendorName_Method("aurora bike center");
            
            Assert.AreEqual("External Lock Washer 3", products1[0]);
            Assert.AreEqual("External Lock Washer 4", products1[1]);
            Assert.AreEqual("External Lock Washer 9", products1[2]);
            Assert.AreEqual("External Lock Washer 5", products1[3]);
            Assert.AreEqual("External Lock Washer 7", products1[4]);
            Assert.AreEqual("External Lock Washer 6", products1[5]);
            Assert.AreEqual("External Lock Washer 1", products1[6]);
            Assert.AreEqual("External Lock Washer 8", products1[7]);
            Assert.AreEqual("External Lock Washer 2", products1[8]);
            Assert.AreEqual("Internal Lock Washer 3", products1[9]);
            Assert.AreEqual("Internal Lock Washer 4", products1[10]);
            Assert.AreEqual("Internal Lock Washer 9", products1[11]);
            Assert.AreEqual("Internal Lock Washer 5", products1[12]);
            Assert.AreEqual("Internal Lock Washer 7", products1[13]);
            Assert.AreEqual("Internal Lock Washer 6", products1[14]);
            Assert.AreEqual("Internal Lock Washer 10", products1[15]);
            Assert.AreEqual("Internal Lock Washer 1", products1[16]);
            Assert.AreEqual("Internal Lock Washer 8", products1[17]);
            Assert.AreEqual("Internal Lock Washer 2", products1[18]);
            }
        }


        [TestMethod]
        public void GetProductNamesByVendorName_Query_Test()
        {
            using (Queries database = new Queries())
            {
                List<string> products1 = database.GetProductNamesByVendorName_Query("aurora bike center");
           
            Assert.AreEqual("External Lock Washer 3", products1[0]);
            Assert.AreEqual("External Lock Washer 4", products1[1]);
            Assert.AreEqual("External Lock Washer 9", products1[2]);
            Assert.AreEqual("External Lock Washer 5", products1[3]);
            Assert.AreEqual("External Lock Washer 7", products1[4]);
            Assert.AreEqual("External Lock Washer 6", products1[5]);
            Assert.AreEqual("External Lock Washer 1", products1[6]);
            Assert.AreEqual("External Lock Washer 8", products1[7]);
            Assert.AreEqual("External Lock Washer 2", products1[8]);
            Assert.AreEqual("Internal Lock Washer 3", products1[9]);
            Assert.AreEqual("Internal Lock Washer 4", products1[10]);
            Assert.AreEqual("Internal Lock Washer 9", products1[11]);
            Assert.AreEqual("Internal Lock Washer 5", products1[12]);
            Assert.AreEqual("Internal Lock Washer 7", products1[13]);
            Assert.AreEqual("Internal Lock Washer 6", products1[14]);
            Assert.AreEqual("Internal Lock Washer 10", products1[15]);
            Assert.AreEqual("Internal Lock Washer 1", products1[16]);
            Assert.AreEqual("Internal Lock Washer 8", products1[17]);
            Assert.AreEqual("Internal Lock Washer 2", products1[18]);
            }
        }

        [TestMethod]
        public void GetProductVendorByProductName_Method_Test()
        {
            using (Queries database = new Queries())
            {
                string vendorName1 = database.GetProductVendorByProductName_Method("External Lock Washer 3");
         

            Assert.AreEqual("Aurora Bike Center", vendorName1);
            }

        }

        [TestMethod]
        public void GetProductVendorByProductName_Query_Test()
        {
            using (Queries database = new Queries())
            {
                string vendorName1 = database.GetProductVendorByProductName_Query("External Lock Washer 3");
           
            Assert.AreEqual("Aurora Bike Center", vendorName1);
            }
        }

        [TestMethod]
        public void GetProductsWithNRecentReviews_Method_Test()
        {
            using (Queries database = new Queries())
            {
                List<Product> products1 = database.GetProductsWithNRecentReviews_Method(4);
         
            Assert.AreEqual(3, products1.Count);
            Assert.AreEqual(709, products1[0].ProductID);
            Assert.AreEqual(798, products1[1].ProductID);
            Assert.AreEqual(937, products1[2].ProductID);
            }
        }

        [TestMethod]
        public void GetProductsWithNRecentReviews_Query_Test()
        {
            using (Queries database = new Queries())
            {
                List<Product> products1 = database.GetProductsWithNRecentReviews_Query(4);

            Assert.AreEqual(3, products1.Count);

            Assert.AreEqual(709, products1[0].ProductID);
            Assert.AreEqual(937, products1[1].ProductID);
            Assert.AreEqual(798, products1[2].ProductID);
            }
        }

        [TestMethod]
        public void GetNRecentlyReviewedProducts_Method_Test()
        {
            using (Queries database = new Queries())
            {
                List<Product> products1 = database.GetNRecentlyReviewedProducts_Method(3);
          
            Assert.AreEqual(3, products1.Count);
            }

        }

        [TestMethod]
        public void GetNRecentlyReviewedProducts_Query_Test()
        {
            using (Queries database = new Queries())
            {
                List<Product> products1 = database.GetNRecentlyReviewedProducts_Query(3);

            Assert.AreEqual(3, products1.Count);
            }
        }

        [TestMethod]
        public void GetNProductsFromCategory_Method_Test()
        {
            using (Queries database = new Queries())
            {
                List<Product> products1 = database.GetNProductsFromCategory_Method("clothing", 3);
            
            Assert.AreEqual(3, products1.Count);

            foreach (Product product in products1)
            {
                Assert.IsTrue(product.ProductSubcategory.ProductCategory.Name.Equals("Clothing"));
            }
            }
        }

        [TestMethod]
        public void GetNProductsFromCategory_Query_Test()
        {
            using (Queries database = new Queries())
            {
                List<Product> products1 = database.GetNProductsFromCategory_Query("clothing", 3);
            
            Assert.AreEqual(3, products1.Count);

            foreach (Product product in products1)
            {
                Assert.IsTrue(product.ProductSubcategory.ProductCategory.Name.Equals("Clothing"));
            }
            }
        }

    }
}
