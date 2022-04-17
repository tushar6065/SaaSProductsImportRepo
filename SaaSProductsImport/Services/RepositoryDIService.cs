using Microsoft.Extensions.DependencyInjection;
using SaaSProductsImport.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSProductsImport.Services
{
    /// <summary>
    /// In future, if we need to change from MySQLRepository to MongoDBRepository, we can easily change it here 
    /// without changing in each class.
    /// </summary>
    public class RepositoryDIService
    {
        private static ServiceProvider serviceProvider;
         static RepositoryDIService()
         {
            serviceProvider = new ServiceCollection()
                .AddScoped<IRepository, MySQLRepository>()
                .BuildServiceProvider();
         }
        
        public static IRepository GetRepositoryInstance()
        {
            try
            {
                return serviceProvider.GetService<IRepository>();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
