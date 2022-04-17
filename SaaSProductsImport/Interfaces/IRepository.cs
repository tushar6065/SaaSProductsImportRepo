using SaaSProductsImport.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSProductsImport.Services.Products
{
    public interface IRepository
    {
        void InsertMany<T>(List<T> Entity) where T : BaseEntity;
    }
}
