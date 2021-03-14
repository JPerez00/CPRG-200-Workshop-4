using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200.TravelExperts.Data
{
    /*
     * Purpose: Business entity class for Products_Suppliers
     * Author: Katrina Spencer
     * Date Created: 02/2021
     */
    public class ProductSupplier
    {
        public int ProductSupplierId { get; set; }
        public int? ProductId { get; set; } // DBNull
        public int? SupplierId { get; set; } // DBNull

        public string ProdName { get; set; }
        public string SupName { get; set; }
    }
}
