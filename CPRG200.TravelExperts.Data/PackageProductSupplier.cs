using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200.TravelExperts.Data
{
    /*
     * Purpose: Business entity class for Packages_Products_Suppliers
     * Author: Katrina Spencer
     * Date Created: 02/2021
     */
    public class PackageProductSupplier
    {
        public int PackageId { get; set; }
        public int ProductSupplierId { get; set; }
        public string ProductSupplierName { get; set; } // added in for more detailed info
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public string ProdName { get; set; }
        public string SupName { get; set; }
    }
}
