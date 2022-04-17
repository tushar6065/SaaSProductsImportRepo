using SaaSProductsImport.Interface;
using SaaSProductsImport.Models.Enum;
using SaaSProductsImport.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSProductsImport.Services
{
    public class ProductSelector
    {
        /// <summary>
        /// This function will return an instance of required service based on Product type
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public IProduct GetProductInstance(string productName)
        {
            switch (productName.ToLower())
            {
                case nameof(ProductEnum.capterra):
                    return new CapterraService();

                case nameof(ProductEnum.softwareadvice):
                    return new SoftwareAdviceService();

                default:
                    throw new ArgumentException("Invalid product name");

            }
        }
    }
}
