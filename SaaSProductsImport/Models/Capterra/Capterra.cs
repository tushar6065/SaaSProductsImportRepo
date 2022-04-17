using SaaSProductsImport.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSProductsImport.Models.Capterra
{
    public class Capterra : BaseEntity
    {
        public string Tags { get; set; }
        public string Name { get; set; }

        public string Twitter { get; set; }
    }
}
