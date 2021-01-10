using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3.MyProduct
{
    class MethodsFMyProdyuct
    {
        private List<MyProduct> products;

        public MethodsFMyProdyuct(ProductionDataContext dataContext)
        {
            products = dataContext.Product.AsEnumerable().Select(product => new MyProduct(product)).ToList();
        }


    }
}
