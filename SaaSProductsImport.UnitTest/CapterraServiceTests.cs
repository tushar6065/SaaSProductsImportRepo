using SaaSProductsImport.Services.Products;
using System;
using System.IO;
using Xunit;

namespace SaaSProductsImport.UnitTest
{
    public class CapterraServiceTests
    {
        private CapterraService capterraService;

        public CapterraServiceTests()
        {
            capterraService = new CapterraService();
        }

        [Fact]
        public void ProcessFile_IOException_OnInvalidPath()
        {
            //Arrange
            var filePath = "someInvalidPath";
            var exceptionMessage = "File path or name is invalid";

            //Act and assert
            var exception = Assert.Throws<IOException>(() => capterraService.ProcessFile(filePath));

            Assert.Equal(exceptionMessage, exception.Message);

        }
    }
}
