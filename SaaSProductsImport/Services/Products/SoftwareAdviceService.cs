using Newtonsoft.Json;
using SaaSProductsImport.Interface;
using SaaSProductsImport.Models.Capterra;
using SaaSProductsImport.Models.SoftwareAdvice;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SaaSProductsImport.Services.Products
{
    public class SoftwareAdviceService : IProduct
    {

        private IRepository _repositorySoftwareAdivce;
        public SoftwareAdviceService()
        {
            _repositorySoftwareAdivce = RepositoryDIService.GetRepositoryInstance();
        }

        /// <summary>
        /// This function takes file path as an input, reads the file from that path
        /// Deserialize it into required model and save it into the db
        /// </summary>
        /// <param name="filePath"></param>
        public void ProcessFile(string filePath)
        {
            try
            {
                var fullfilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "\\" + filePath;
                using (var reader = new StreamReader(fullfilePath))
                {
                    string content = reader.ReadToEnd();
                    SoftwareAdvice softwareAdvice = JsonConvert.DeserializeObject<SoftwareAdvice>(content);
                    foreach (var item in softwareAdvice.Products)
                    {
                        ///importing                    
                        Console.WriteLine($"importing: Title: \"{item.Title}\"; Categories: {string.Join(",", item.Categories)}; Twitter: {item.Twitter ?? "Not Applicable"}");
                    }

                    ///saving to db
                    _repositorySoftwareAdivce.InsertMany<SoftwareAdviceProduct>(softwareAdvice.Products);

                }
            }
            catch (IOException)
            {
                throw new IOException("File path or name is invalid");
            }
            catch (Exception)
            {
                throw new IOException("Invalid input");
            }


        }
    }
}
