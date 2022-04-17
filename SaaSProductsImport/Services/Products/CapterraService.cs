using SaaSProductsImport.Interface;
using SaaSProductsImport.Models.Capterra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace SaaSProductsImport.Services.Products
{
    public class CapterraService : IProduct
    {
        private IRepository _repositorySoftwareAdivce;

        public CapterraService()
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
                    var deserializer = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
                    List<Capterra> listCapterra = deserializer.Deserialize<List<Capterra>>(reader);
                    foreach (var item in listCapterra)
                    {
                        ///importing and writing into console                                
                        Console.WriteLine($"importing: Name: \"{item.Name}\"; Tags: {item.Tags}; Twitter: @{ item.Twitter ?? "Not Applicable"}");
                    }

                    ///saving to db
                    _repositorySoftwareAdivce.InsertMany<Capterra>(listCapterra);

                }
            }
            catch(IOException)
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
