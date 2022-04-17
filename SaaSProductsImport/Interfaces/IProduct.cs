using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSProductsImport.Interface
{
    public interface IProduct
    {
        public void ProcessFile(string filePath);
    }
}
