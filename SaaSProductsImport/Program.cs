using SaaSProductsImport.Interface;
using SaaSProductsImport.Services;
using System;
using System.Reflection;

namespace SaaSProductsImport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ProcessInput();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            finally
            {
                ProcessInput();
            }

        }

        private static void ProcessInput()
        {
            try
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Please enter the command for importing data.");
                var commandString = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(commandString))
                {
                    ProcessInput();
                }

                var productName = commandString.Split(" ")[1];
                var filePath = commandString.Split(" ")[2];

                ProductSelector productSelector = new ProductSelector();
                IProduct product1 = productSelector.GetProductInstance(productName);
                product1.ProcessFile(filePath);
                ProcessInput();
                Console.ReadKey();
            }
            catch (IndexOutOfRangeException ex)
            {                
                throw new Exception("Invalid or incomplete command");
            }
            catch (ArgumentException ex)
            {                
                throw new Exception("Invalid product"); 
            }
            catch (Exception ex)
            {                
                throw new Exception("Invalid or incomplete command");
            }
            
        }
    }
}