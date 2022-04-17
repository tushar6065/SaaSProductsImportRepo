using SaaSProductsImport.Models.Domain;
using SaaSProductsImport.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSProductsImport.Services
{
    class MongoDBRepository : IRepository
    {        
        public void InsertMany<T>(List<T> Entity) where T : BaseEntity
        {
            ////Logic for saving list of entities to mongo db
        }
    }
}
