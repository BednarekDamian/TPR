using System;

namespace Zadanie3.MyProduct
{
    class MyProduct
    {
        public int ProductId { get; set; }
        public string ProductNumber { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal ListPrice { get; set; }
        public DateTime SellStartDate { get; set; }
        public ProductSubcategory SCategory { get; set; }
        public string PSize { get; set; }

        public MyProduct(Product product)
        {
            ProductId = product.ProductID;
            ProductNumber = product.ProductNumber;
            Name = product.Name;
            Color = product.Color;
            ListPrice = product.ListPrice;
            SellStartDate = product.SellStartDate;
            SCategory = product.ProductSubcategory;
            PSize = product.Size;
        }

        public override bool Equals(object obj)
        {
            MyProduct myProduct = (MyProduct)obj;
            return this.ProductId.Equals(myProduct.ProductId);
        }
    }
}
