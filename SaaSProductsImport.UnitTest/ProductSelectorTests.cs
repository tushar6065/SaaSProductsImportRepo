using SaaSProductsImport.Services;
using SaaSProductsImport.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SaaSProductsImport.UnitTest
{
    public class ProductSelectorTests
    {
        private ProductSelector productSelector;

        public ProductSelectorTests()
        {
            productSelector = new ProductSelector();
        }

        [Fact]
        public void GetProductInstance_ThrowsArgumentExceptionWhenInvalidProduct()
        {
            //Arrange
            var productName = "dummy";
            var exceptionMessage = "Invalid product name";

            //Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => productSelector.GetProductInstance(productName));
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData("capterra", "softwareadvice")]
        [InlineData("CapTerra", "SoftwareAdvice")]
        [InlineData("CAPTERRA", "SOFTWAREADVICE")]
        public void GetProductInstance_ReturnValidInstanceOnValidProduct_AndCaseInsensitive(string productNameCapterra, string productNameSoftwareAdvice)
        {
            ////Arrange
            //var capterra = productNameCapterra;
            //var softwareAdvice = productNameSoftwareAdvice;


            //Act
            var resultCaptera = productSelector.GetProductInstance(productNameCapterra);
            var resultSoftwareAdvice = productSelector.GetProductInstance(productNameSoftwareAdvice);


            // and Assert
            Assert.IsType<SoftwareAdviceService>(resultSoftwareAdvice);
            Assert.IsType<CapterraService>(resultCaptera);
        }
    }
}
