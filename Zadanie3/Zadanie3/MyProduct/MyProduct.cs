using System;

namespace Zadanie3
{
    public class MyProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public decimal StandardCost { get; set; }
        public int? ProductSubcategoryId { get; set; }
        public ProductSubcategory ProductSubcategory { get; set; }
        public DateTime ModifiedDate { get; set; }

        public MyProduct(Product product)
        {
            ProductId = product.ProductID;
            Name = product.Name;
            ProductNumber = product.ProductNumber;
            StandardCost = product.StandardCost;
            ProductSubcategoryId = product.ProductSubcategoryID;
            ProductSubcategory = product.ProductSubcategory;
            ModifiedDate = product.ModifiedDate;
        }

        public override bool Equals(object obj)
        {
            MyProduct product = (MyProduct)obj;
            return this.ProductId.Equals(product.ProductId);
        }
    }
}
