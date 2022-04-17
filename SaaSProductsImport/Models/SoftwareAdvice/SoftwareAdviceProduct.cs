using SaaSProductsImport.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSProductsImport.Models.SoftwareAdvice
{
    public class SoftwareAdviceProduct : BaseEntity
    {
        public List<string> Categories { get; set; }

        public string Twitter { get; set; }

        public string Title { get; set; }
    }
}
